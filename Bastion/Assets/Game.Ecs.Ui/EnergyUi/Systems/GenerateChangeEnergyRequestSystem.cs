namespace Game.Ecs.Ui.EnergyUi.Systems
{
    using System;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;

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
    public class GenerateChangeEnergyRequestSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.ViewFilter<AddEnergyButtonViewModel>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var addEnergyButtonViewModel = _world.GetViewModel<AddEnergyButtonViewModel>(entity);
                if (addEnergyButtonViewModel.addEnergy.Value)
                {
                    addEnergyButtonViewModel.addEnergy.Value = false;
                    var newEntity = _world.NewEntity();
                    //todo add request to change energy
                }
            }

        }
    }
}