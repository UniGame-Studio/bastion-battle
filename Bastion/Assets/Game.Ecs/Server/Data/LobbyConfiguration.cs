namespace Game.Ecs.Server.Data
{
    using System;

    [Serializable]
    public class LobbyConfiguration
    {
        public float SyncPeriod = 1f;
        public int SelectionCooldown = 10;
        public int GameStartCooldown = 10;
    }
}