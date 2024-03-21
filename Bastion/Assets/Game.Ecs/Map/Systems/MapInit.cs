using Game.Ecs.Core.Components;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;

namespace Game.Ecs.Map.Systems
{
    using System;
    using System.Linq;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

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
    public class MapInit : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _cellFilter;
        private EcsFilter _mapFilter;
        private MapAspect _mapAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _cellFilter = _world
                .Filter<CellComponent>()
                //.Exc<OwnerComponent>()
                .End();

            _mapFilter = _world
                .Filter<MapComponent>()
                .End();
            
            foreach (var mapEntity in _mapFilter)
            {
                foreach (var cellEntity in _cellFilter)
                {
                    ref var ownerComponent = ref _world.AddComponent<OwnerComponent>(cellEntity);
                    ownerComponent.Value = mapEntity.PackedEntity(_world);
                    
                    ref var emptyCountComponent = ref _mapAspect.EmptyCellsCount.Get(mapEntity);
                    emptyCountComponent.Count++;
                }
            }
            
        }
    }
}