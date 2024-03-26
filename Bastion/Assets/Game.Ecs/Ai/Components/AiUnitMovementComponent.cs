namespace Game.Ecs.Ai.Components
{
    using System;

    /// <summary>
    /// Marks entity as an AI agent.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct AiUnitMovementComponent
    {
        
    }
}