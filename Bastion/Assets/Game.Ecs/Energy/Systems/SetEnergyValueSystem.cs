namespace Game.Ecs.Energy.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using Requests;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// System for DIRECT change energy value and max energy value 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SetEnergyValueSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EnergyAspect _energyAspect;
        private EcsFilter _energyFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<SetEnergyRequest>().End();
            
            _energyFilter = _world.Filter<EnergyComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var request = ref _energyAspect.Set.Get(entity);
                foreach (var energyEntity in _energyFilter)
                {
                    ref var energyComponent = ref _energyAspect.Energy.Get(energyEntity);
                    
                    energyComponent.MaxEnergy = request.MaxValue;
                    energyComponent.Energy = Mathf.Clamp(request.Value, 0, energyComponent.MaxEnergy);
                }
            }

        }
    }
}