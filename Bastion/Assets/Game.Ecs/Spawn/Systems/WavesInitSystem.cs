using System.Collections.Generic;
using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Data;
using Unity.Collections;

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
    /// init wave entities with data and start first wave
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WavesInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private WavesSpawnDataAsset _wavesSpawnDataAsset;
        private SpawnAspect _spawnAspect;
        private WaveAspect _waveAspect;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _wavesSpawnDataAsset = _world.GetGlobal<WavesSpawnDataAsset>();

            int spawnEntity = _world.NewEntity();
            ref var currentWave = ref _spawnAspect.Wave.Add(spawnEntity);
            ref var waveOrder = ref _spawnAspect.WaveOrder.Add(spawnEntity);
            ref var cooldown = ref _spawnAspect.Cooldown.Add(spawnEntity);

            List<WaveData> waves = _wavesSpawnDataAsset.Data.Waves;
            waveOrder.Waves = new NativeHashMap<int, EcsPackedEntity>(waves.Count, Allocator.Persistent);
            for (int i = 0; i < waves.Count; i++)
            {
                int waveEntity = _world.NewEntity();
                ref var waveData = ref _waveAspect.Data.Add(waveEntity);
                waveData.Data = waves[i];
                waveOrder.Waves.Add(i, waveEntity.PackedEntity(_world));
            }

            currentWave.Index = 0;
            _spawnAspect.WaveStartEvent.Add(spawnEntity);
        }
    }
}