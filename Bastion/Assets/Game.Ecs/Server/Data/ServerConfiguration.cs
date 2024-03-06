namespace Game.Ecs.Server.Data
{
    using System;
    using Sirenix.OdinInspector;
    using UnityEngine.Serialization;

    [Serializable]
    public class ServerConfiguration
    {
        public string serverName = string.Empty;    
        public string serverVersion = "0.0.1";
        public int maxPlayers = 4;
        public int maxRooms = 1;
        public int tickRate = 20;
        public bool createHostAtStart;
    }
}