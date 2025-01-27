﻿using UnityEngine.Serialization;

namespace Game.Ecs.Spawn.Components
{
    using System;

    /// <summary>
    /// unit cooldown data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct UnitCooldownComponent
    {
        public float Time;
        public bool Immediately;
    }
}