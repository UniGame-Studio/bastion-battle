namespace Game.Ecs.Ui.EnergyUi.Systems
{
    using System;
    using Energy.Aspects;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;

    /// <summary>
    /// Test system for generate change energy request
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class GenerateChangeEnergyRequestSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _addFilter;
        private EnergyAspect _energyAspect;
        private EcsFilter _removeFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _addFilter = _world.ViewFilter<AddEnergyButtonViewModel>().End();
            _removeFilter = _world.ViewFilter<RemoveEnergyViewModel>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _addFilter)
            {
                var addEnergyButtonViewModel = _world.GetViewModel<AddEnergyButtonViewModel>(entity);
                if (addEnergyButtonViewModel.addEnergy.Take())
                {
                    addEnergyButtonViewModel.addEnergy.Value = false;
                    var newEntity = _world.NewEntity();
                    ref var addEnergyRequest = ref _energyAspect.AddRequest.Add(newEntity);
                    addEnergyRequest.Value = 10;
                }
                
            }
            
            foreach (var entity in _removeFilter)
            {
                var removeEnergyViewModel = _world.GetViewModel<RemoveEnergyViewModel>(entity);
                if (removeEnergyViewModel.removeEnergy.Take())
                {
                    var newEntity = _world.NewEntity();
                    ref var removeEnergyRequest = ref _energyAspect.RemoveRequest.Add(newEntity);
                    removeEnergyRequest.Value = 10;
                }
            }

        }
    }
}