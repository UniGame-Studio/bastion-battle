using System;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Game.Ecs.SelectUnit.View;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Shared.Extensions;
using UniGame.LeoEcs.ViewSystem.Extensions;

namespace Game.Ecs.SelectUnit.Systems
{
    [Serializable]
    [ECSDI]
    public class MapUiCommandsSystem  : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private MapAspect _mapAspect;
        private EcsFilter _filter;
        private EcsFilter _mapFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.ViewFilter<MapCommandsViewModel>().End();
            _mapFilter = _world.Filter<MapComponent>().End();
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
                    request.ResourceId = "Test Unit Square";
                    request.TargetMap = mapEntity.PackedEntity(_world);
                }
            }
        }
    }
}