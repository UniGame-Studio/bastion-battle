namespace Game.Ecs.Ai.Navigation.Systems
{
    using System;
    using System.Linq;
    using Ai.Components;
    using GameLayers.Layer.Components;
    using GameLayers.Relationship.Systems;
    using Leopotam.EcsLite;
    using Movement.Components;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;

    /// <summary>
    /// Система приказывает юнитам двигаться к вражескому кристаллу
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SetDestinationToEnemySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _aiUnitGroup;
        private EcsFilter _enemyCrystalGroup;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _aiUnitGroup = _world.Filter<AiUnitMovementComponent>()
                .Inc<NavMeshAgentComponent>()
                .Inc<LayerIdComponent>()
                .Exc<MovementPointRequest>().End();
            _enemyCrystalGroup = _world.Filter<CrystalComponent>()
                .Inc<LayerIdComponent>()
                .Inc<TransformPositionComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var aiUnit in _aiUnitGroup)
            {
                foreach (var enemyCrystal in _enemyCrystalGroup)
                {
                    ref var layerId = ref _world.GetComponent<LayerIdComponent>(enemyCrystal);
                    ref var aiUnitLayerId = ref _world.GetComponent<LayerIdComponent>(aiUnit);
                    if(layerId.Value == aiUnitLayerId.Value)
                        continue;
                    
                    ref var enemyCrystalPosition = ref _world.GetComponent<TransformPositionComponent>(enemyCrystal);
                    ref var movementPointRequest = ref _world.AddComponent<MovementPointRequest>(aiUnit);
                    movementPointRequest.DestinationPosition = enemyCrystalPosition.Position;
                }
            }
        }
    }
}