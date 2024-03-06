namespace Game.Ecs.Server.Data
{
    using System;

    [Serializable]
    public class ServerStatesData
    {
        public ServerStateData[] states = Array.Empty<ServerStateData>(); 
    }
}