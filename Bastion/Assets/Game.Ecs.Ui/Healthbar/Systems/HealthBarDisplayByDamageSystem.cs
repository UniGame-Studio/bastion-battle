namespace Game.Ecs.UI.HealthBar.Systems
{
    using System;
    using Characteristics.Health.Components;
    using Components;
    using Core.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using Unit.Components;

    /// <summary>
    /// if unit has less hp than max hp - show health bar
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class HealthBarDisplayByDamageSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _healthBarFilter ;
        private EcsFilter _creepFilter;
        private EcsPool<HealthComponent> _healthPool;
        private EcsPool<OwnerComponent> _ownerPool;
        private EcsPool<HealthBarDisplayedComponent> _healthBarDisplayedPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _healthBarFilter = _world.ViewFilter<HealthBarViewModel>()
                .Inc<OwnerComponent>()
                .End();
            _creepFilter = _world.Filter<UnitComponent>()
                .Exc<HealthBarDisplayedComponent>()
                .Inc<HealthComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var creepEntity in _creepFilter)
            {
                ref var healthComponent = ref _healthPool.Get(creepEntity);
                if(Math.Abs(healthComponent.Health - healthComponent.MaxHealth) < float.Epsilon) continue;

                foreach (var healthBarEntity in _healthBarFilter)
                {
                    var healthBarViewModel = _world.GetViewModel<HealthBarViewModel>(healthBarEntity);
                    ref var ownerComponent = ref _ownerPool.Get(healthBarEntity);
                    
                    if (!ownerComponent.Value.Unpack(_world, out var ownerEntity)) continue;
                    if (ownerEntity != creepEntity) continue;
                    
                    healthBarViewModel.isShow.SetValue(true);
                    _healthBarDisplayedPool.Add(creepEntity);
                }
            }
        }
    }
}