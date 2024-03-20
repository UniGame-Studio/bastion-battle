using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

namespace Game.Ecs.Map.Aspects
{
    public class MapAspect : EcsAspect
    {
        public EcsPool<CellComponent> Cells;

        public EcsPool<SetUnitOnMapRequest> SetUnit;
    }
}