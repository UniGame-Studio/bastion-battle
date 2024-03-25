using Unity.Collections;

namespace Game.Ecs.Map.Components
{
    using System;

    /// <summary>
    /// for find maps
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct MapComponent
    {
        public NativeHashSet<int> CellIds;
    }
}