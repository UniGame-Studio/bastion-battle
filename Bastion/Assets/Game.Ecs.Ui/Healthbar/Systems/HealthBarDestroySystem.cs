namespace Game.Ecs.UI.HealthBar.Systems
{
    using Characteristics.Health.Components;
    using Core.Components;
    using Core.Death.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.ViewSystem.Components;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using Unity.IL2CPP.CompilerServices;
    using Views;
    
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public sealed class HealthBarDestroySystem : IEcsRunSystem,IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsFilter _disableFilter;
        private EcsWorld _world;
        private EcsPool<OwnerComponent> _ownerPool;
        private EcsPool<ViewComponent> _viewModelPool;
        private EcsPool<PrepareToDeathComponent> _preparePool;
        private EcsFilter _notLinkedFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .ViewFilter<HealthBarViewModel>()
                .Inc<OwnerComponent>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var ownerComponent = ref _ownerPool.Get(entity);
                
                if (!ownerComponent.Value.Unpack(_world, out var ownerEntity))
                    continue;

                if (!_preparePool.Has(ownerEntity)) continue;
                
                ref var viewModel = ref _viewModelPool.Get(entity);
                viewModel.View.Close();
            }
        }
    }
}
