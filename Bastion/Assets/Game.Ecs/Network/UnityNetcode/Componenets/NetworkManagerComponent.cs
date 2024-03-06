namespace Girand.Ecs.GameSettings.Componenets
{
    using System;
    using Unity.Netcode;

    /// <summary>
    /// netcode Manager
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct NetworkManagerComponent
    {
        public NetworkManager Value;
    }
}