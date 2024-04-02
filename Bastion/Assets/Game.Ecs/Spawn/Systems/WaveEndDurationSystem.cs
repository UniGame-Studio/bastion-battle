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
    /// check for end wave and delete unit spawn cooldowns
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WaveEndDurationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsFilter _unitSpawnFilter;
        private SpawnAspect _spawnAspect;
        private WaveAspect _waveAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CurrentWaveComponent>()
                .Inc<CooldownCompleteComponent>()
                .Exc<RestartCooldownSelfRequest>()
                .End();

            _unitSpawnFilter = _world.Filter<UnitCooldownComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _filter)
            {
                _spawnAspect.DurationState.Del(spawnEntity);
                _spawnAspect.WaveEndEvent.Add(spawnEntity);

                foreach (var unitSpawnEntity in _unitSpawnFilter)
                {
                    _world.DelEntity(unitSpawnEntity);
                }
            }
        }
    }
}