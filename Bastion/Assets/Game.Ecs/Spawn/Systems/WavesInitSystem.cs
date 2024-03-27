using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Data;

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
    public class WavesInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private WavesSpawnDataAsset _wavesSpawnDataAsset;
        private SpawnAspect _spawnAspect;
        private WaveAspect _waveAspect;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _wavesSpawnDataAsset = systems.GetShared<WavesSpawnDataAsset>();

            int spawnEntity = _world.NewEntity();
            ref var waveIndex = ref _spawnAspect.Wave.Add(spawnEntity);
            ref var waveOrder = ref _spawnAspect.WaveOrder.Add(spawnEntity);
            ref var cooldown = ref _spawnAspect.Cooldown.Add(spawnEntity);

            for (int i = 0; i < _wavesSpawnDataAsset.Data.Waves.Count; i++)
            {
                int waveEntity = _world.NewEntity();
                ref var waveData = ref _waveAspect.Data.Add(waveEntity);
                waveData.Data = _wavesSpawnDataAsset.Data.Waves[i];
                waveOrder.Waves.Add(i, waveEntity.PackedEntity(_world));
            }
        }
    }
}