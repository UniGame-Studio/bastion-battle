﻿namespace Game.Ecs.Server.Components.Requests
{
    using System;

    /// <summary>
    /// start new server room
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CreateServerRoomSelfRequest
    {
        public string RoomName;
        public int MaxPlayers;
        public bool Visible;
        public bool Open;
    }
}