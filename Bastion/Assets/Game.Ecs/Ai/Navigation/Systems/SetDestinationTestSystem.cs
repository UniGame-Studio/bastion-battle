namespace Game.Ecs.Ai.Navigation.Systems
{
    using System;
    using System.Linq;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using Unity.Mathematics;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SetDestinationTestSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private readonly float3 _destination;
        private EcsFilter _agentFilter;

        public SetDestinationTestSystem(float3 destination)
        {
            _destination = destination;
        }
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _agentFilter = _world.Filter<NavigationAgentComponent>().Exc<MoveToTargetComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var agentEntity in _agentFilter)
            {
                ref var component = ref _world.GetComponent<NavigationAgentComponent>(agentEntity);
                component.agent.SetDestination(_destination);
                ref var moveToTargetComponent = ref _world.AddComponent<MoveToTargetComponent>(agentEntity);
                moveToTargetComponent.destination = _destination;
            }

        }
    }
}