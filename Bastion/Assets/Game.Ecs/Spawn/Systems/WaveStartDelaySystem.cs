using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Components;
using Game.Ecs.Spawn.Data.Events;
using UniGame.LeoEcs.Timer.Components;

namespace Game.Ecs.Spawn.Systems
{
    using System;
    using System.Linq;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// init and start time for wave delay
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WaveStartDelaySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _spawnFilter;
        private SpawnAspect _spawnAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _spawnFilter = _world
                .Filter<WaveOrderComponent>()
                .Inc<CurrentWaveDelayComponent>()
                .Inc<CurrentWaveDurationComponent>()
                .Inc<CooldownComponent>()
                .Exc<CooldownActiveComponent>()
                .Exc<CooldownCompleteComponent>()
                .Inc<WaveDelayStateComponent>()
                .Exc<WaveDurationStateComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _spawnFilter)
            {
                ref var cooldown = ref _spawnAspect.Cooldown.Get(spawnEntity);
                ref var waveDelay = ref _spawnAspect.WaveDelay.Get(spawnEntity);
                cooldown.Value = waveDelay.Time;
                _spawnAspect.ActiveCooldown.Add(spawnEntity);
            }
        }
    }
}