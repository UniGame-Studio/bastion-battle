namespace Game.Ecs.Ai.Systems
{
    using System;
    using Ability.Aspects;
    using Ability.Common.Components;
    using Ability.Components.Requests;
    using Ability.SubFeatures.AbilitySwitcher.Aspects;
    using Ability.Tools;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Timer.Components;
    using UnityEngine;

    /// <summary>
    /// System for applying units abilities by cooldown
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ApplyUnitsAbilitiesByCooldownSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private AbilityAspect _abilityAspect;
        private AbilitySwitcherAspect _abilitySwitcherAspect;
        private EcsPool<AbilityInHandLinkComponent> _abilityInHandLinkPool;
        private EcsPool<ApplyAbilityBySlotSelfRequest> _applyAbilityBySlotSelfRequestPool;
        private TimerAspect _timerAspect;
        private AbilityTools _abilityTools;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _abilityTools = _world.GetGlobal<AbilityTools>();
            _filter = _world.Filter<AbilityInHandLinkComponent>()
                .Exc<ActivateAbilitySelfRequest>()
                .Exc<ActiveAbilityComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var abilityInHandEntity in _filter)
            {
                ref var ecsPackedEntity = ref _abilityInHandLinkPool.Get(abilityInHandEntity);

                if (!ecsPackedEntity.AbilityEntity.Unpack(_world, out var abilityEntityUnpacked))
                    continue;
                
                if (!_abilityTools.IsAbilityCooldownPassed(abilityEntityUnpacked)) continue;
                //todo хз как работает абилити кулдаун
                _abilityTools.ActivateAbility(_world, abilityEntityUnpacked);
                _timerAspect.Cooldown.GetOrAddComponent(abilityEntityUnpacked);
                _timerAspect.AutoRestart.GetOrAddComponent(abilityEntityUnpacked);
                Debug.LogWarning( $"Activate ability {abilityEntityUnpacked} request is added to entity: " + abilityInHandEntity + " by ApplyUnitsAbilitiesByCooldownSystem.");
            }

        }
    }
}