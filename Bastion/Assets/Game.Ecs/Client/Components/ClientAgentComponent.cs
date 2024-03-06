namespace Game.Ecs.Client.Components
{
    using System;
    using UnityEngine.Serialization;

    /// <summary>
    /// game client point
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ClientAgentComponent
    {
        public bool IsConnected;
        public bool IsMaster;
        public bool IsInRoom;
        [FormerlySerializedAs("PlayerId")]
        public int Id;
    }
}