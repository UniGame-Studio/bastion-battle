namespace Game.Ecs.Client.Data
{
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine.AddressableAssets;
    using UnityEngine.Serialization;

    [Serializable]
    public class ClientConfiguration
    {
        public AssetReferenceGameObject client;
        
        public List<ClientState> states = new();
        
        [TitleGroup("Gameplay Data")]
        [InlineProperty]
        [HideLabel]
        public ClientGameplayData gameplayData = new();
    }
}