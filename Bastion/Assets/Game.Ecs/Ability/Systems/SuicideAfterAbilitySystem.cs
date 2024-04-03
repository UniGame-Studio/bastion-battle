namespace Game.Ecs.Ability.Systems
{
    using System;
    using Common.Components;
    using Components;
    using Core.Components;
    using Effects;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UnityEngine;

    /// <summary>
    /// Система самоуничтожения после окончания действия умения. Обрабатывает компонент <see cref="SuicideAfterAbilityComponent"/>
    /// который вешается в <see cref="SuicideAfterAbilityEffects"/>.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SuicideAfterAbilitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<PrepareToDeathComponent> _prepareToDeathPool;
        private EcsPool<OwnerComponent> _ownerPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<SuicideAfterAbilityComponent>()
                .Inc<AbilitySlotComponent>()
                .Inc<AbilityCompleteSelfEvent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var abilityEntity in _filter)
            {
                ref OwnerComponent ownerComponent = ref _ownerPool.Get(abilityEntity);
                if(!ownerComponent.Value.Unpack(_world, out var ownerEntity)) continue;
                
                ref var prepareToDeath = ref _prepareToDeathPool.Add(ownerEntity); 
                prepareToDeath.Source = ownerComponent.Value;

#if UNITY_EDITOR
                Debug.Log($"Prepare to death after melee attack. Entity: {ownerEntity}, should die");
#endif
            }

        }
    }
}