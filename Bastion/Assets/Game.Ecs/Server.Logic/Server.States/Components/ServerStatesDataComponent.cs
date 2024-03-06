namespace Game.Ecs.Server.Features.Server.States.Components
{
    using System;
    using Data;

    /// <summary>
    /// info about available server states
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ServerStatesDataComponent
    {
        public ServerStateData[] states;
    }
}