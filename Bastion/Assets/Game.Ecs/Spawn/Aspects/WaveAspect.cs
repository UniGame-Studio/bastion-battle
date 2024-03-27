using Game.Ecs.Spawn.Components;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Timer.Components;
using UniGame.LeoEcs.Timer.Components.Requests;

namespace Game.Ecs.Spawn.Aspects
{
    using System;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class WaveAspect : EcsAspect
    {
        // wave config
        public EcsPool<WaveDataComponent> Data;

        // unit congigs
        public EcsPool<UnitCooldownComponent> UnitCooldown;
        public EcsPool<UnitResourceComponent> UnitResource;
        
        // unit cooldown
        public EcsPool<CooldownComponent> Cooldown;
        public EcsPool<CooldownRemainsTimeComponent> RemainsCooldown;
        public EcsPool<CooldownActiveComponent> ActiveCooldown;
        public EcsPool<RestartCooldownSelfRequest> RestartCooldown;
    }
}