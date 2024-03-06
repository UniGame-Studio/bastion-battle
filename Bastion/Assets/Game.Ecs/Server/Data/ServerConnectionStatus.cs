namespace Game.Ecs.Server.Data
{
    using System;

    [Serializable]
    public enum ServerConnectionStatus
    {
        Initializing,
        Initialized,
        Starting,
        Started,
        Stopping,
        Stopped,
    }
}