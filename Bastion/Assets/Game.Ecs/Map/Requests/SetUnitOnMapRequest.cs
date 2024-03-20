using System;
using Leopotam.EcsLite;

namespace Game.Ecs.Map.Requests
{
    [Serializable]
    public struct SetUnitOnMapRequest
    {
        public string UnitResourceId;
        public EcsPackedEntity Target;
    }
}