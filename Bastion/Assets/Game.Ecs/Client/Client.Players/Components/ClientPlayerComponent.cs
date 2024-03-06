namespace Girand.Ecs.Server.Components
{
    using System;

    /// <summary>
    /// player data of client
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ClientPlayerComponent
    {
        public int Id;
        public string Name;
        public string GUID;
        public string Token;
    }
}