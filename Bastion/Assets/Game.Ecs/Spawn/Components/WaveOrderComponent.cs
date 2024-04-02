using Leopotam.EcsLite;
using Unity.Collections;

namespace Game.Ecs.Spawn.Components
{
    using System;

    /// <summary>
    /// component with hash map index - WaveData
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct WaveOrderComponent
    {
        public NativeHashMap<int, EcsPackedEntity> Waves;
    }
}