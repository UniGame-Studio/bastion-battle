namespace Game.Ecs.NetworkCommands.Components.Events
{
    using System;

    /// <summary>
    /// player ready event
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ToServerPlayerReadyEvent
    {
        public int Sender;
    }
}