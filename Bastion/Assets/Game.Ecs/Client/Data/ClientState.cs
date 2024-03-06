namespace Game.Ecs.Client.Data
{
    using System;
    using System.Collections.Generic;
    using Runtime.Services.AddressablesSource;
    using UniGame.MultiScene.Runtime;
    using UnityEngine.SceneManagement;

    [Serializable]
    public class ClientState
    {
        public string state;
        public AssetReferenceMultiScene scene;
        public LoadSceneMode loadMode = LoadSceneMode.Single;
        public bool aActivateOnLoad = true;
        public bool reload;
        
        public AddressableGameObjects addressableGameObjects;
    }
}