﻿namespace Game.Ecs.UI.HealthBar.Components
{
    using System;
    using UnityEngine;

    /// <summary>
    /// heath bar camera component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct HealthBarCameraComponent
    {
        public Camera Camera;
    }
}