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
    /// System handles Add or Remove energy request
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class AddOrRemoveEnergySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _energyFilter;
        private EcsFilter _addFilter;
        private EcsFilter _removeFilter;
        private EnergyAspect _energyAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _addFilter = _world.Filter<AddEnergyRequest>().End();
            _removeFilter = _world.Filter<RemoveEnergyRequest>().End();
            _energyFilter = _world.Filter<EnergyComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var addRequest in _addFilter)
            {
                foreach (var energyEntity in _energyFilter)
                {
                    ref var energyComponent = ref _energyAspect.Energy.Get(energyEntity);
                    ref var request = ref _energyAspect.AddRequest.Get(addRequest);

                    if (energyComponent.Energy + request.Value > energyComponent.MaxEnergy)
                        energyComponent.Energy = energyComponent.MaxEnergy;
                    else
                        energyComponent.Energy += request.Value;
                }            }
            
            foreach (var removeRequest in _removeFilter)
            {
                foreach (var energyEntity in _energyFilter)
                {
                    ref var energyComponent = ref _energyAspect.Energy.Get(energyEntity);
                    ref var request = ref _energyAspect.RemoveRequest.Get(removeRequest);

                    if(request.Value > energyComponent.Energy)
                        _energyAspect.NotEnough.Add(_world.NewEntity());
                    else
                        energyComponent.Energy -= request.Value;
                }
            }
        }
    }
}