namespace Game.Ecs.Ai.Navigation.Components
{
    using System;
    using Unity.Mathematics;

    /// <summary>
    /// Navigation destination component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct MoveToTargetComponent
    {
        public float3 destination;
    }
}