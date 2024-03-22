using Game.Ecs.Core.Components;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

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
    /// for select random cell and request for set on cell
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SetOnRandomCellSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private MapAspect _mapAspect;
        private EcsFilter _mapFilter;
        private EcsFilter _requestFilter;
        private EcsFilter _cellFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _requestFilter = _world
                .Filter<SetOnRandomCellRequest>()
                .End();
            
            _mapFilter = _world
                .Filter<EmptyCellCountComponent>()
                .End();

            _cellFilter = _world
                .Filter<CellComponent>()
                .Inc<ParentEntityComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var requestEntity in _requestFilter)
            {
                ref var setOnRandomCellRequest = ref _mapAspect.SetUnitOnRandomCell.Get(requestEntity);

                foreach (var mapEntity in _mapFilter)
                {
                    if (!setOnRandomCellRequest.TargetMap.Unpack(_world, out var targetMap)) continue;
                    
                    if(mapEntity != targetMap) continue;
                    
                    ref var mapEmptyCountComponent = ref _mapAspect.EmptyCellsCount.Get(mapEntity);
                    
                    if(mapEmptyCountComponent.Count <= 0) continue;

                    EcsPackedEntity[] emptyCells = new EcsPackedEntity[mapEmptyCountComponent.Count];

                    int emptyCellIndex = 0;

                    foreach (var cellEntity in _cellFilter)
                    {
                        ref var cellComponent = ref _mapAspect.Cell.Get(cellEntity);
                        ref var parentComponent = ref _mapAspect.Parent.Get(cellEntity);
                        
                        if(!parentComponent.Value.Unpack(_world, out int cellOwner)) continue;
                        
                        if(cellOwner != targetMap) continue;
                        
                        if(!cellComponent.IsEmply) continue;
                        
                        emptyCells[emptyCellIndex++] = cellEntity.PackedEntity(_world);
                    }
                    
                    if(emptyCells.Length <= 0) continue;
                    
                    EcsPackedEntity randomCell = emptyCells[UnityEngine.Random.Range(0, emptyCells.Length)];
                    
                    var newRequestEntity = _world.NewEntity();
                    ref var newSetRequest = ref _world.GetOrAddComponent<SetOnCellRequest>(newRequestEntity);
                    newSetRequest.ResourceId = setOnRandomCellRequest.ResourceId;
                    newSetRequest.TargetCell = randomCell;
                    newSetRequest.TargetMap = setOnRandomCellRequest.TargetMap;
                }
            }
        }
    }
}