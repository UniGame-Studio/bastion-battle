namespace Game.Ecs.Ai.Navigation.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using Unity.Mathematics;

    /// <summary>
    /// Moving to target system. Check distance to target and stop moving if distance less than threshold
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class MovingToTargetSystem : IEcsInitSystem, IEcsRunSystem
    {
        private const float MinSquaredDistance = 1;
        
        
        private EcsWorld _world;
        private EcsFilter _filter;
        private NavigationAspect _aspect;
        private EcsPool<TransformPositionComponent> _positionPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<MoveToTargetComponent>().Inc<NavigationAgentComponent>().Exc<UnmovableComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var movableEntity in _filter)
            {
                ref var agentComponent = ref _aspect.NavigationAgent.Get(movableEntity);
                ref var moveToTarget = ref _aspect.MoveToTarget.Get(movableEntity);
                ref var positionComponent = ref _positionPool.Get(movableEntity);
                ref var agentSettings = ref _aspect.Settings.Get(movableEntity);
                var agent = agentComponent.agent;
                var distance = math.distancesq(positionComponent.Position, moveToTarget.destination);
                
                if (distance < agentSettings.stoppingDistanceSqr)
                {
                    agent.isStopped = true;
                    _aspect.MoveToTarget.Del(movableEntity);
                    //либо создать событие о достижении цели
                    _aspect.DestinationIsReached.Add(_world.NewEntity());
                }
            }
        }

    }
}