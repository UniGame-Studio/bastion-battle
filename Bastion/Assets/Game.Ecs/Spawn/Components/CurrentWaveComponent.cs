﻿namespace Game.Ecs.Spawn.Components
{
    using System;

    /// <summary>
    /// current wave data 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct CurrentWaveComponent
    {
        public int Index;
        public float Delay;
        public float Duration;
    }
}