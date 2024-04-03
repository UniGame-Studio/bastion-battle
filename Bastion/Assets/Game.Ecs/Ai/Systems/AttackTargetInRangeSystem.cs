namespace Game.Ecs.Ai.Systems
{
    using System;
    using Ability.Aspects;
    using Ability.Components;
    using Ability.SubFeatures.Selection.Components;
    using Ability.SubFeatures.Target.Components;
    using Ability.SubFeatures.Target.Tools;
    using Ability.Tools;
    using Core.Components;
    using Leopotam.EcsLite;
    using TargetSelection.Aspects;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

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
    public class AttackTargetInRangeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private AbilityTools _abilityTools;
        private AbilityAspect _abilityAspect;
        private TargetAspect _targetAspect;
        private EcsFilter _abilitiesFilter;
        private AbilityTargetTools _abilityTargetTools;
        private EcsPool<AbilityTargetsComponent> _abilityTargetPool;
        private EcsPool<SelectedTargetsComponent> _selectedTargetsPool;
        

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
                ref SelectedTargetsComponent selectedTargetsComponent = ref  _selectedTargetsPool.Get(abilityEntity);
                ref AbilityTargetsComponent abilityTargetsComponent = ref _abilityTargetPool.Get(abilityEntity);
                ref AbilitySlotComponent abilitySlotComponent = ref  _abilityAspect.AbilitySlot.Get(abilityEntity);
                ref OwnerComponent ownerComponent = ref _abilityAspect.Owner.Get(abilityEntity);
                if(!_abilityTools.IsAbilityCooldownPassed(abilityEntity)) continue;
                
                if (selectedTargetsComponent.Count == 0) continue;
                if (ownerComponent.Value.Unpack(_world, out var ownerEntity) == false) continue;

                var targetPackedEntity = selectedTargetsComponent.Entities[0];//не знаю пока на что заменить эту строчку
                if (!targetPackedEntity.Unpack(_world, out var targetEntity)) continue;

                _abilityTargetTools.SetAbilityTarget(ownerEntity, targetPackedEntity, _abilityAspect.AbilitySlot.Get(abilityEntity).SlotType);
                if (abilityTargetsComponent.Count == 0) continue;
                
                _abilityTools.ActivateAbility(_world, abilityEntity);
            }
        }
    }
}