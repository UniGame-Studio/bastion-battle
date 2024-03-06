namespace Game.Ecs.Server.Data
{
    using System;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public class AddressableServerSource
    {
        public AssetReferenceGameObject value;
        public bool immortal;
        public bool killWithState;
    }
}