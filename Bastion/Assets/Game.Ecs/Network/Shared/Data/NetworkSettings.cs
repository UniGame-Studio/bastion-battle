namespace Game.Ecs.Network.Shared.Data
{
    using System;

    [Serializable]
    public class NetworkSettings
    {
        public string serverAddress = "127.0.0.1";
        public ushort serverPort = 0;
    }
}