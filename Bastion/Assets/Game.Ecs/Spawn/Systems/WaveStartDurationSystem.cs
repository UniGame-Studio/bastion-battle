using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Components;
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
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WaveStartDurationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SpawnAspect _spawnAspect;
        private EcsFilter _spawnFilter;


        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _spawnFilter = _world
                .Filter<WaveOrderComponent>()
                .Inc<CurrentWaveDelayComponent>()
                .Inc<CurrentWaveDurationComponent>()
                .Inc<CooldownComponent>()
                .Exc<WaveDelayStateComponent>()
                .Inc<WaveDurationStateComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _spawnFilter)
            {
                ref var cooldown = ref _spawnAspect.Cooldown.Get(spawnEntity);
                ref var waveDelay = ref _spawnAspect.WaveDelay.Get(spawnEntity);
                cooldown.Value = waveDelay.Time;
                
                // создать сущности кулдаунов для юнитов
            }
        }
    }
}

