﻿namespace Girand.Ecs.GameSettings.Components.Events
{
    using System;
    using Photon.Realtime;

    /// <summary>
    /// connected to photon network disconnected event.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct NetworkDisconnectedSelfEvent
    {
        public DisconnectCause Value;
    }
}