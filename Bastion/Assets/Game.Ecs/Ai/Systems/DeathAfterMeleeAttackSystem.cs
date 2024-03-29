namespace Game.Ecs.Ai.Systems
{
    using System;
    using System.Linq;
    using Ability.Common.Components;
    using Ability.Components;
    using Core.Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// Mark entity with PrepareToDeathComponent after melee attack
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class DeathAfterMeleeAttackSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _completedAbilityFilter;
        private EcsPool<PrepareToDeathComponent> _prepareToDeathPool;
        

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _completedAbilityFilter = _world.Filter<AbilitySlotComponent>().Inc<AbilityCompleteSelfEvent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var abilityEntity in _completedAbilityFilter)
            {
                //сейчас мы не проверяем, что абилка является атакой, но в реальной игре это нужно будет сделать
                //сущность будет умирать после любой абилки
                ref OwnerComponent ownerComponent = ref _world.GetComponent<OwnerComponent>(abilityEntity);
                if(!ownerComponent.Value.Unpack(_world, out var ownerEntity)) continue;
                
                ref var prepareToDeath = ref _prepareToDeathPool.Add(ownerEntity); 
                prepareToDeath.Source = ownerComponent.Value;

                Debug.Log($"Prepare to death after melee attack. Entity: {ownerEntity}, should die");
            }

        }
    }
}