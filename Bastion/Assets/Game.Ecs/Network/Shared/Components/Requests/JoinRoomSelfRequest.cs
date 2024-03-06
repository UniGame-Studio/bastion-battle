﻿namespace Game.Ecs.Network.Shared.Components.Requests
{
    using System;

    /// <summary>
    /// try to make connection to room
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct JoinRoomSelfRequest
    {
        
    }
}