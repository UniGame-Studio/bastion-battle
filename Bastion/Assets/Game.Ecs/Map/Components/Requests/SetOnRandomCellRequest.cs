using Leopotam.EcsLite;

namespace Game.Ecs.Map.Requests
{
    public struct SetOnRandomCellRequest
    {
        public string ResourceId;
        public EcsPackedEntity TargetMap;
    }
}