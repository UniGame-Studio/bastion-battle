using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

namespace Game.Ecs.SetUnit.Data
{
    [Serializable]
    public class CurrentCharactersSpawnData
    {
        public List<AssetReference> Units;
    }
}