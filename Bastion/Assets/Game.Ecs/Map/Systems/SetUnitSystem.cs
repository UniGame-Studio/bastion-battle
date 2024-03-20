using Game.Ecs.GameResources.Systems;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Game.Ecs.Map.Tools;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

namespace Game.Ecs.Map.Systems
{
    [ECSDI]
    public class SetUnitSystem : IEcsRunSystem, IEcsInitSystem
    {
        private GameSpawnTools _gameSpawnTools;
        private EcsFilter _filter;
        private EcsWorld _world;
        private MapAspect _mapAspect;
            
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<SetUnitOnMapRequest>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var setRequest = ref _mapAspect.SetUnit.Get(entity);
                if(!setRequest.Target.Unpack(_world, out int cellEntity)) continue;
                ref var cellComponent = ref _mapAspect.Cells.Get(cellEntity);

                _gameSpawnTools.Spawn(setRequest.UnitResourceId, cellComponent.Position.position);
            }
        }
    }
}