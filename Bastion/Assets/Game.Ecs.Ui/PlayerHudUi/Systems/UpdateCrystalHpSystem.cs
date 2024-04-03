namespace Game.Ecs.Ui.PlayerHudUi.Systems
{
    using System;
    using System.Linq;
    using Ai.Components;
    using Characteristics.Health.Components;
    using Code.GameLayers.Layer;
    using GameLayers.Category.Components;
    using GameLayers.Layer.Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using Views;

    /// <summary>
    /// Update crystal hp system for player hud ui
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateCrystalHpSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _uiFilter;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _uiFilter = _world.ViewFilter<CrystalsHpViewModel>().End();
            _filter = _world.Filter<HealthComponent>()
                .Inc<LayerIdComponent>()
                .Inc<CategoryIdComponent>()
                .Inc<CrystalComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            //todo add ceckin for team by layerId and CategoryId
            foreach (var uiEntity in _uiFilter)
            {
                foreach (var entity in _filter)
                {
                    var crystalsHpViewModel = _world.GetViewModel<CrystalsHpViewModel>(uiEntity);
                    ref var healthComponent = ref _world.GetComponent<HealthComponent>(entity);
                    crystalsHpViewModel.hp.SetValue(healthComponent.Health);
                }
                
            }
        }
    }
}