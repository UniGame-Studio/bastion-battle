namespace Girand.Runtime.Services.GameSettings
{
    using System;
    using Game.Ecs.Game.Data;
    using Game.Runtime.Services.AddressablesSource;
    using Sirenix.OdinInspector;
    using UnityEngine.Serialization;

    [Serializable]
    public class GameSettings
    {
        [FormerlySerializedAs("ClientType")]
        [EnumToggleButtons]
        public BuildType gameMode = BuildType.Server;
        
        public GameModeValue[] gameModes = Array.Empty<GameModeValue>();
    }
    
    [Serializable]
    public class GameModeValue
    {
        public BuildType buildType = BuildType.Client;
        
        [InlineProperty]
        [HideLabel]
        public AddressableGameObjects assets = new();
    }
}
