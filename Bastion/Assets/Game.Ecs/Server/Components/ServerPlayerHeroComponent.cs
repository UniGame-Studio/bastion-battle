namespace Game.Ecs.Server.Components
{
    using System;
    using Leopotam.EcsLite;

    /// <summary>
    /// selected player hero 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct ServerPlayerHeroComponent : IEcsAutoReset<ServerPlayerHeroComponent>
    {
        public int Champion;
        public bool IsLocked;
        
        public void AutoReset(ref ServerPlayerHeroComponent c)
        {
            c.Champion = default;
            c.IsLocked = false;
        }
    }
}