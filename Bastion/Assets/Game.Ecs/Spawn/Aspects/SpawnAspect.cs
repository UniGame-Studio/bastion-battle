using Game.Ecs.Spawn.Components;
using Game.Ecs.Spawn.Data;
using Game.Ecs.Spawn.Data.Events;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Timer.Components;
using UniGame.LeoEcs.Timer.Components.Requests;

namespace Game.Ecs.Spawn.Aspects
{
    using System;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// waves spawn aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class SpawnAspect : EcsAspect
    {
        // spawn config
        public EcsPool<SpawnPointComponent> SpawnPoint;
        public EcsPool<WaveOrderComponent> WaveOrder;
        
        // current wave parameters
        public EcsPool<CurrentWaveIndexComponent> Wave;
        public EcsPool<CurrentWaveDurationComponent> WaveDuration;
        public EcsPool<CurrentWaveDelayComponent> WaveDelay;
        
        // current wave state
        public EcsPool<CooldownComponent> Cooldown;
        public EcsPool<CooldownRemainsTimeComponent> RemainsCooldown;
        public EcsPool<CooldownActiveComponent> ActiveCooldown;
        public EcsPool<WaveDelayStateComponent> DelayState;
        public EcsPool<WaveDurationStateComponent> DurationState;
        public EcsPool<RestartCooldownSelfRequest> RestartCooldown;
        
        // events
        public EcsPool<WaveStartEvent> WaveStartEvent;
        public EcsPool<WaveEndEvent> WaveEndEvent;
        public EcsPool<WavesEndedEvent> WavesEndedEvent;
    }
}