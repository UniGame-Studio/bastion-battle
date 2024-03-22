namespace Game.Ecs.Ai.Navigation.Events
{
    using System;

    /// <summary>
    /// Event that is sent when the destination is reached by the navigation agent
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct DestinationIsReachedEvent
    {
        
    }
}