namespace Game.Ecs.UI.HealthBar.Systems
{
    using Components;
    using Config;
    using Core.Components;
    using GameLayers.Layer.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;

    /// <summary>
    /// Sets HealthBar color based onto LayerIdColorConfiguration
    /// </summary>
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public sealed class HealthBarColorSystem : IEcsRunSystem, IEcsInitSystem
    {
        private LayerIdColorConfiguration _layerIdColor;
        private EcsFilter _filter;
        private EcsFilter _filterHealthBars;
        private EcsWorld _world;
        
        private EcsPool<OwnerComponent> _ownerPool;
        private EcsPool<LayerIdComponent> _layerIdPool;
        private EcsPool<HealthBarColoredComponent> _healthBarColoredPool;

        public HealthBarColorSystem(LayerIdColorConfiguration layerIdColorConfiguration)
        {
            _layerIdColor = layerIdColorConfiguration;
        }

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filterHealthBars = _world
                .ViewFilter<HealthBarViewModel>()
                .Inc<OwnerComponent>()
                .Exc<HealthBarColoredComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var barEntity in _filterHealthBars)
            {
                ref var ownerComponent = ref _ownerPool.Get(barEntity);
                if (!ownerComponent.Value.Unpack(_world, out var ownerEntity))
                    continue;

                if (!_layerIdPool.Has(ownerEntity))
                    continue;
                
                if (!_world.TryGetViewModel(barEntity, out HealthBarViewModel healthBarViewModel))
                    continue;
                
                ref var ownerLayerId = ref _layerIdPool.Get(ownerEntity);
                ref var healthColorComponent = ref _healthBarColoredPool.Add(barEntity);
                healthColorComponent.Color = _layerIdColor.GetLayerIdColor(ownerLayerId.Value);
            }
        }
    }
}