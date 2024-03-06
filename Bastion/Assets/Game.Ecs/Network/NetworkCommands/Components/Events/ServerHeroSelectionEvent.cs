namespace Game.Ecs.NetworkCommands.Components.Events
{
    using System;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UnityEngine.Serialization;

    /// <summary>
    /// notify about player hero selection
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ServerHeroSelectionEvent
    {
        public int Sender;
        public int ClientId;
        public int HeroId;
        public bool Locked;
    }
}