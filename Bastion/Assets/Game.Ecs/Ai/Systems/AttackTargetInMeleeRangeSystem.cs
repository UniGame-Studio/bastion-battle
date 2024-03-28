namespace Game.Ecs.Ai.Systems
{
    using System;
    using System.Linq;
    using Ability.Aspects;
    using Ability.Common.Components;
    using Ability.Components;
    using Ability.SubFeatures.Selection.Components;
    using Ability.SubFeatures.Target.Components;
    using Ability.SubFeatures.Target.Tools;
    using Ability.Tools;
    using Core.Components;
    using Core.Death.Components;
    using Gameplay.Death.Aspects;
    using Leopotam.EcsLite;
    using TargetSelection.Aspects;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Timer.Components;
    using Unit.Components;

    /// <summary>
    /// System for attack target in melee range
    /// if entity get target in ability range - activate ability (attack)
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class AttackTargetInMeleeRangeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private AbilityTools _abilityTools;
        private TargetAspect _targetAspect;
        private AbilityAspect _abilityAspect;
        private EcsFilter _abilitiesFilter;
        private EcsFilter _filter;
        private AbilityTargetTools _abilityTargetTools;
        private DeathAspect _deathAspect;
        private TimerAspect _timerAspect;
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _abilityTools = _world.GetGlobal<AbilityTools>();
            _abilityTargetTools = _world.GetGlobal<AbilityTargetTools>();
            
            _abilitiesFilter = _world.Filter<AbilityTargetsComponent>()
                .Inc<AbilitySlotComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            //можно разделить абилки по слотам (дефолт - для ближней атаки по кристаллу, другие для специальных атак по башням игрока)
            //поэтому нужно будет добавить фильтр по слоту абилки
            foreach (var abilityEntity in _abilitiesFilter)
            {
                ref SelectedTargetsComponent selectedTargetsComponent = ref _world.GetComponent<SelectedTargetsComponent>(abilityEntity);
                ref AbilityTargetsComponent abilityTargetsComponent = ref _world.GetComponent<AbilityTargetsComponent>(abilityEntity);
                ref AbilitySlotComponent abilitySlotComponent = ref _world.GetComponent<AbilitySlotComponent>(abilityEntity);
                ref OwnerComponent ownerComponent = ref _world.GetComponent<OwnerComponent>(abilityEntity);
                
                if (selectedTargetsComponent.Count == 0) continue;
                if (ownerComponent.Value.Unpack(_world, out var ownerEntity) == false) continue;

                //todo разобраться с кулдауном
                //hard code
                var targetPackedEntity = selectedTargetsComponent.Entities[0];
                if (!targetPackedEntity.Unpack(_world, out var targetEntity)) continue;
                _abilityTargetTools.SetAbilityTarget(ownerEntity, targetPackedEntity, _abilityAspect.AbilitySlot.Get(abilityEntity).SlotType);
                if (abilityTargetsComponent.Count == 0) continue;
                if(!_abilityTools.IsAbilityCooldownPassed(abilityEntity)) continue;
                _abilityTools.ActivateAbility(_world, abilityEntity);
                _timerAspect.Restart.GetOrAddComponent(abilityEntity); 
                //todo add death request
                ref var prepareToDeath = ref _deathAspect.PrepareToDeath.Add(ownerEntity); 
                prepareToDeath.Source = ownerComponent.Value;
                
                Debug.Log("Attack target in melee range!");
            }
        }
    }
}