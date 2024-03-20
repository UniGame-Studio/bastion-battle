using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Ecs.Ability.Components.Requests;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Shared.Extensions;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Game.Ecs.Map.Tools
{
    [ECSDI]
    public class MapTools : IEcsInitSystem
    {
        private EcsWorld _world;
        private MapAspect _mapAspect;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<CellComponent>()
                .End();
            
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUnitOnRandomCell(string resourceId)
        {
            List<EcsPackedEntity> cells = new List<EcsPackedEntity>();
            foreach (var filter in _filter)
            {
                cells.Add(filter.PackedEntity(_world));
            }

            EcsPackedEntity randomCell = cells[Random.Range(0, cells.Count)];
            var requestEntity = _world.NewEntity();
            ref var setRequest = ref _world.GetOrAddComponent<SetUnitOnMapRequest>(requestEntity);
            setRequest.UnitResourceId = resourceId;
            setRequest.Target = randomCell;
        }
    }
}