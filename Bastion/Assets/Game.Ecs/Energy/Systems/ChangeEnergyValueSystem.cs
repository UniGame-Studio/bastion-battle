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
    public class ChangeEnergyValueSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _energyFilter;
        private EnergyAspect _energyAspect;
        private EcsFilter _changeEnergyFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _changeEnergyFilter = _world.Filter<ChangeEnergyRequest>().End();
            _energyFilter = _world.Filter<EnergyComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var changeRequest in _changeEnergyFilter)
            {
                foreach (var energyEntity in _energyFilter)
                {
                    ref var energyComponent = ref _energyAspect.Energy.Get(energyEntity);
                    ref var request = ref _energyAspect.ChangeRequest.Get(changeRequest);

                    energyComponent.Energy =
                        Mathf.Clamp(energyComponent.Energy + request.Value, 0, energyComponent.MaxEnergy);
                    
                    //check if energy is not enough
                    if(request.Value < 0 && request.Value > energyComponent.Energy)
                    {
                        var eventEntity = _world.NewEntity();
                        _energyAspect.NotEnough.Add(eventEntity);
                    }
                }
            }
        }
    }
}