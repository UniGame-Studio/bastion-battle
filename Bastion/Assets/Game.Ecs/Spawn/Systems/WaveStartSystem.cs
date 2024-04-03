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
    /// set current wave data and start delay
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
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _spawnFilter)
            {
                ref var wavesOrder = ref _spawnAspect.WaveOrder.Get(spawnEntity);
                ref var currentWave = ref _spawnAspect.Wave.Get(spawnEntity);
                        
                if(!wavesOrder.Waves[currentWave.Index].Unpack(_world, out int waveEntity)) continue;

                ref var waveDataComponent = ref _waveAspect.Data.Get(waveEntity);
                    
                // вносим параметры новой волны

                WaveData data = waveDataComponent.Data;
                currentWave.Delay = data.Delay;
                currentWave.Duration = data.Duration;

                foreach (var unitSpawnData in data.Units)
                {
                    int newUnitEntity = _world.NewEntity();
                    ref var unitCooldown = ref _waveAspect.UnitCooldown.Add(newUnitEntity);
                    ref var unitResource = ref _waveAspect.UnitResource.Add(newUnitEntity);

                    unitCooldown.Time = unitSpawnData.Cooldown;
                    unitCooldown.Immediately = unitSpawnData.SpawnImmediately;
                    unitResource.Value = unitSpawnData.UnitReference;
                }
                
                _spawnAspect.DelayState.Add(spawnEntity);
            }
        }
    }
}