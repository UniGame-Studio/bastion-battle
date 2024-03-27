﻿using Game.Ecs.Spawn.Aspects;
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
    public class WaveEndDelaySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SpawnAspect _spawnAspect;
        private EcsPool<CooldownRemainsTimeComponent> _remainsPool;
        private EcsPool<CooldownComponent> _cooldownPool;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .Filter<CurrentWaveDelayComponent>()
                .Inc<WaveDelayStateComponent>()
                .Exc<WaveDurationStateComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _filter)
            {
                ref var remains = ref _remainsPool.Get(spawnEntity);
                
                if(remains.Value > 0) continue;
                
                _spawnAspect.DelayState.Del(spawnEntity);
                _spawnAspect.DurationState.Add(spawnEntity);
            }
        }
    }
}