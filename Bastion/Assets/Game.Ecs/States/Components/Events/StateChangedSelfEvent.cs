﻿namespace Game.Ecs.Server.Components.Events
{
    using System;

    /// <summary>
    /// notify about state change
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct StateChangedSelfEvent<TComponent>
    {
        public int From;
        public int To;
    }
}