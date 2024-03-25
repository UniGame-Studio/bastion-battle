using System;
using Game.Code.Services.AbilityLoadout.Data;
using UnityEngine.AddressableAssets;

namespace Game.Ecs.Spawn.Data
{
    [Serializable]
    public class UnitSpawnData
    {
        public AssetReference UnitReference;
        public float Cooldown;
        public bool SpawnImmediately;
    }
}