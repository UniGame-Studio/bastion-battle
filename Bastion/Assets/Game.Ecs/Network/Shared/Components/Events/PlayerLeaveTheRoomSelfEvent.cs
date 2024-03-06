﻿namespace Game.Ecs.Network.Shared.Components.Events
{
    using System;

    /// <summary>
    /// player leave the room
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct PlayerLeaveTheRoomSelfEvent
    {
        public int PlayerId;
        public int RoomId;
    }
}