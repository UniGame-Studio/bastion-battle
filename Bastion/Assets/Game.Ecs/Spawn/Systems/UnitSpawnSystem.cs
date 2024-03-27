using Game.Ecs.GameResources.Systems;
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
    public class UnitSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsFilter _spawnFilter;
        private WaveAspect _waveAspect;
        private GameSpawnTools _gameSpawnTools;
        private SpawnAspect _spawnAspect;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameSpawnTools = _world.GetGlobal<GameSpawnTools>();
            
            _filter = _world
                .Filter<CooldownRemainsTimeComponent>()
                .Inc<UnitCooldownComponent>()
                .End();

            _spawnFilter = _world.Filter<SpawnPointComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var unitSpawnEntity in _filter)
            {
                ref var remains = ref _waveAspect.RemainsCooldown.Get(unitSpawnEntity);
                
                if (remains.Value > 0) continue;

                ref var unitResource = ref _waveAspect.UnitResource.Get(unitSpawnEntity);

                foreach (var spawnPointEntity in _spawnFilter)
                {
                    ref var spawnPoint = ref _spawnAspect.SpawnPoint.Get(spawnPointEntity);
                    _gameSpawnTools.Spawn(unitResource.Value.AssetGUID, spawnPoint.Position);
                }
                    
                _waveAspect.RestartCooldown.Add(unitSpawnEntity);
            }
        }
    }
}