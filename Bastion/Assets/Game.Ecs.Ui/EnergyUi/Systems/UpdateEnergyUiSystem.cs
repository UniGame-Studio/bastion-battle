namespace Game.Ecs.Ui.EnergyUi.Systems
{
    using System;
    using Energy.Aspects;
    using Energy.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;

    /// <summary>
    /// Update Energy Ui System
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateEnergyUiSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _energyFilter;
        private EcsFilter _viewFilter;
        private EnergyAspect _energyAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _energyFilter = _world.Filter<EnergyComponent>().End();
            _viewFilter = _world.ViewFilter<EnergyUiViewModel>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var viewFilter in _viewFilter)
            {
                var energyUiViewModel = _world.GetViewModel<EnergyUiViewModel>(viewFilter);
                foreach (var energyEntity in _energyFilter)
                {
                    ref var energyComponent = ref _energyAspect.Energy.Get(energyEntity);
                    energyUiViewModel.energy.Value = energyComponent.Energy;
                }
            }

        }
    }
}