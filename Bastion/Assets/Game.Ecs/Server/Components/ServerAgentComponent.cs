namespace Game.Ecs.Server.Components
{
    using System;

    /// <summary>
    /// server actor component.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ServerAgentComponent
    {
        public bool IsConnected;
        public bool IsMaster;
        public bool IsReady;
        public bool IsInRoom;
    }
}