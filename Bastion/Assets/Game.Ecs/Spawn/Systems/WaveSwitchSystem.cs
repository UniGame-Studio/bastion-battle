using Game.Ecs.Spawn.Aspects;
using Game.Ecs.Spawn.Data.Events;

namespace Game.Ecs.Spawn.Systems
{
    using System;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// start next wave or end event
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class WaveSwitchSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SpawnAspect _spawnAspect;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world.Filter<WaveEndEvent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnEntity in _filter)
            {
                ref var currentWave = ref _spawnAspect.Wave.Get(spawnEntity);
                currentWave.Index++;
                ref var waveOrder = ref _spawnAspect.WaveOrder.Get(spawnEntity);
                
                if (waveOrder.Waves.ContainsKey(currentWave.Index))
                    _spawnAspect.WaveStartEvent.Add(spawnEntity);
                else
                    _spawnAspect.WavesEndedEvent.Add(spawnEntity);
            }
        }
    }
}