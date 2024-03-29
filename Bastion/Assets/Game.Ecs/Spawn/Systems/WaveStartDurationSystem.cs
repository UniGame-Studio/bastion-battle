using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Components;
using UniGame.LeoEcs.Timer.Components;
using UniGame.LeoEcs.Timer.Components.Requests;

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
    /// init cooldowns wave units spawn and duration time
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
        private WaveAspect _waveAspect;
        private EcsFilter _spawnFilter;
        private EcsFilter _unitSpawnFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _spawnFilter = _world
                .Filter<WaveOrderComponent>()
                .Inc<CurrentWaveDelayComponent>()
                .Inc<CurrentWaveDurationComponent>()
                .Inc<CooldownComponent>()
                .Exc<WaveDelayStateComponent>()
                .Inc<CooldownCompleteComponent>()
                .Inc<RestartCooldownSelfRequest>()
                .Inc<WaveDurationStateComponent>()
                .End();

            _unitSpawnFilter = _world.Filter<UnitCooldownComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _spawnFilter)
            {
                ref var waveCooldown = ref _spawnAspect.Cooldown.Get(spawnEntity);
                ref var waveDuration = ref _spawnAspect.WaveDuration.Get(spawnEntity);
                waveCooldown.Value = waveDuration.Time;
                
                // накидываем кулдауны для спавна юнитов
                foreach (var unitSpawnEntity in _unitSpawnFilter)
                {
                    ref var unitCooldown = ref _waveAspect.UnitCooldown.Get(unitSpawnEntity);
                    ref var cooldown = ref _waveAspect.Cooldown.Add(unitSpawnEntity);
                    cooldown.Value = unitCooldown.Time;
                    _waveAspect.ActiveCooldown.Add(unitSpawnEntity);
                    
                    if(!unitCooldown.Immediately) continue;

                    _waveAspect.CompleteCooldown.Add(unitSpawnEntity);
                }
            }
        }
    }
}

