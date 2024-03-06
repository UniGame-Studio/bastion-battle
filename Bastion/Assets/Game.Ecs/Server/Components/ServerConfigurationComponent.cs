﻿namespace Game.Ecs.Server.Components
{
    using System;

    /// <summary>
    /// server configuration data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ServerConfigurationComponent
    {
        public string Version;
        public int RoomMaxPlayers;
        public string ServerName;
    }
}