namespace Game.Ecs.UI.HealthBar.Systems
{
    using Characteristics.Health.Components;
    using Characteristics.Shield.Components;
    using Components;
    using Core.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using UnityEngine;

    /// <summary>
    /// Update HealthBar data via model HealthBarViewModel
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public sealed class HealthBarUpdateShieldSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsWorld _world;
        private EcsFilter _cameraFilter;

        private EcsPool<HealthComponent> _healthDataPool;
        private EcsPool<HealthBarTargetComponent> _healthBarsPool;
        private EcsPool<ShieldComponent> _shieldPool;
        private EcsPool<OwnerComponent> _ownerLinkPool;
        private EcsPool<HealthBarCameraComponent> _cameraPool;
        private EcsPool<HealthBarColoredComponent> _healthColorPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world
                .ViewFilter<HealthBarViewModel>()
                .Inc<HealthBarColoredComponent>()
                .Inc<OwnerComponent>()
                .End();

            _cameraFilter = _world
                .Filter<HealthBarCameraComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            Camera camera = default;
            
            foreach (var cameraEntity in _cameraFilter)
            {
                ref var cameraComponent = ref _cameraPool.Get(cameraEntity);
                camera = cameraComponent.Camera;
                break;
            }

            if (camera == null) return;
            
            foreach (var viewEntity in _filter)
            {
                ref var ownerLink = ref _ownerLinkPool.Get(viewEntity);
                if (!ownerLink.Value.Unpack(_world, out var ownerEntity))
                    continue;
                
                if (!_world.TryGetViewModel(viewEntity, out HealthBarViewModel healthBarViewModel))
                    continue;

                if (_shieldPool.Has(ownerEntity))
                {
                    ref var shield = ref _shieldPool.Get(ownerEntity);
                    healthBarViewModel.shield.Value = shield.Value;
                }
                else
                {
                    healthBarViewModel.shield.Value = 0;
                }
            }
        }
    }
}