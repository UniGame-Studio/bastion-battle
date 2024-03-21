using Game.Ecs.GameResources.Systems;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Shared.Extensions;

namespace Game.Ecs.Map.Systems
{
    [ECSDI]
    public class SetOnCellSystem : IEcsRunSystem, IEcsInitSystem
    {
        private GameSpawnTools _gameSpawnTools;
        private EcsFilter _filter;
        private EcsWorld _world;
        private MapAspect _mapAspect;
            
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameSpawnTools = _world.GetGlobal<GameSpawnTools>();
            
            _filter = _world
                .Filter<SetOnCellRequest>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var setRequest = ref _mapAspect.SetUnitOnCell.Get(entity);
                
                if(!setRequest.TargetCell.Unpack(_world, out int cellEntity)) continue;
                
                ref var transform = ref _mapAspect.Transform.Get(cellEntity);
                _gameSpawnTools.Spawn(setRequest.ResourceId, transform.Value.position);
            }
        }
    }
}