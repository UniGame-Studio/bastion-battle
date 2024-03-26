using System;
using Leopotam.EcsLite;
using UnityEngine.Serialization;

namespace Game.Ecs.Map.Requests
{
    [Serializable]
    public struct SetOnCellRequest
    {
        public string ResourceId;
        public EcsPackedEntity TargetCell;
        public EcsPackedEntity TargetMap;
    }
}