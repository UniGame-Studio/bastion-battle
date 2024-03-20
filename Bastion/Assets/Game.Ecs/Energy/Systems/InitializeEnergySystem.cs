namespace Game.Ecs.Energy.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Components;
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
    public class InitializeEnergySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EnergyAspect _energyAspect;
        private EnergySettings _setup;
        
        public InitializeEnergySystem(EnergySettings setup)
        {
            _setup = setup;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<EnergyComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            if (_filter.GetEntitiesCount() > 0) return;
            var entity = _world.NewEntity();
            ref var energyComponent = ref _energyAspect.Energy.Add(entity);
            
            energyComponent.Energy = _setup.StartEnergy;
            energyComponent.MaxEnergy = _setup.MaxEnergy;
        }
    }
}