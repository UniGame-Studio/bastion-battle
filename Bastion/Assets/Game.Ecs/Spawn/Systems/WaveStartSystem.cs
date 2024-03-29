using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Components;
using Game.Ecs.Spawn.Data;
using Game.Ecs.Spawn.Data.Events;

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
    public class WaveStartSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SpawnAspect _spawnAspect;
        private WaveAspect _waveAspect;
        private EcsFilter _spawnFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _spawnFilter = _world
                .Filter<WaveOrderComponent>()
                .Inc<WaveStartEvent>()
                .Inc<CurrentWaveDelayComponent>()
                .Inc<CurrentWaveDurationComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _spawnFilter)
            {
                ref var wavesOrder = ref _spawnAspect.WaveOrder.Get(spawnEntity);
                ref var waveIndex = ref _spawnAspect.Wave.Get(spawnEntity);
                        
                if(!wavesOrder.Waves[waveIndex.Value].Unpack(_world, out int waveEntity)) continue;

                ref var waveDataComponent = ref _waveAspect.Data.Get(waveEntity);
                ref var currentWaveDelay = ref _spawnAspect.WaveDelay.Get(spawnEntity);
                ref var currentWaveDuration = ref _spawnAspect.WaveDuration.Get(spawnEntity);
                    
                // вносим параметры новой волны

                WaveData data = waveDataComponent.Data;
                currentWaveDelay.Time = data.Delay;
                currentWaveDuration.Time = data.Duration;

                foreach (var unitSpawnData in data.Units)
                {
                    CreateNewUnitEntity(unitSpawnData);
                }
                
                _spawnAspect.DelayState.Add(spawnEntity);
            }
        }

        private void CreateNewUnitEntity(UnitSpawnData data)
        {
            int newUnitEntity = _world.NewEntity();
            ref var unitCooldown = ref _waveAspect.UnitCooldown.Add(newUnitEntity);
            ref var unitResource = ref _waveAspect.UnitResource.Add(newUnitEntity);

            unitCooldown.Time = data.Cooldown;
            unitCooldown.Immediately = data.SpawnImmediately;
            unitResource.Value = data.UnitReference;
        }
    }
}