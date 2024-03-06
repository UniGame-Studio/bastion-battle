namespace Game.Ecs.Client.Components.Events
{
    using System;

    /// <summary>
    /// notify about active scene changed
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ActiveSceneChangedSelfEvent
    {
        
    }
}