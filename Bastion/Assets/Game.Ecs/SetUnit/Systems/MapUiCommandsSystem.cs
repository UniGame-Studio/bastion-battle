
using System;
using System.Collections.Generic;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Game.Ecs.SetUnit.Data;
using Game.Ecs.SetUnit.View;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Shared.Extensions;
using UniGame.LeoEcs.ViewSystem.Extensions;
using Random = UnityEngine.Random;

namespace Game.Ecs.SetUnit.Systems
{
    [Serializable]
    [ECSDI]
    public class MapUiCommandsSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private MapAspect _mapAspect;
        private EcsFilter _filter;
        private EcsFilter _mapFilter;
        private CurrentCharactersSpawnData _spawnData;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.ViewFilter<MapCommandsViewModel>().End();
            _mapFilter = _world.Filter<MapComponent>().End();
            _spawnData = _world.GetGlobal<CurrentCharactersSpawnData>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var mapEntity in _mapFilter)
            {
                foreach (var entity in _filter)
                {
                    var model = _world.GetViewModel<MapCommandsViewModel>(entity);
                
                    if(!model.AddUnitAction.Take()) continue;
                
                    var requestEntity = _world.NewEntity();
                    ref var request = ref _world.GetOrAddComponent<SetOnRandomCellRequest>(requestEntity);
                    int randomUnitIndex = Random.Range(0, _spawnData.Units.Count);
                    request.ResourceId = _spawnData.Units[randomUnitIndex].AssetGUID;
                    request.TargetMap = mapEntity.PackedEntity(_world);
                }
            }
        }
    }
}