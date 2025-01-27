﻿using Game.Ecs.Spawn.Data;

namespace Game.Ecs.Spawn.Components
{
    using System;

    /// <summary>
    /// wave config data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct WaveDataComponent
    {
        public WaveData Data;
    }
}