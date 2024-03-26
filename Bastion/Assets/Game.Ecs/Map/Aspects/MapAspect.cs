using Game.Ecs.Core.Components;
using Game.Ecs.Map.Components;
using Game.Ecs.Map.Requests;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
using UniGame.LeoEcs.Shared.Components;
using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

namespace Game.Ecs.Map.Aspects
{
    public class MapAspect : EcsAspect
    {
        public EcsPool<MapComponent> Map;
        
        //cells
        public EcsPool<CellComponent> Cell;
        public EcsPool<CellIdComponent> CellId;
        public EcsPool<OwnerComponent> Owner;
        public EcsPool<EmptyCellCountComponent> EmptyCellsCount;
        public EcsPool<TransformComponent> Transform;

        //requests
        public EcsPool<SetOnCellRequest> SetUnitOnCell;
        public EcsPool<SetOnRandomCellRequest> SetUnitOnRandomCell;
    }
}