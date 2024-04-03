namespace Game.Ecs.UI.HealthBar.Systems
{
    using System;
    using System.Collections.Generic;
    using Aspects;
    using Characteristics.Health.Components;
    using Components;
    using Core.Death.Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using UniModules.UniGame.UiSystem.Runtime;
    using UnityEngine;
    using Views;

    /// <summary>
    /// Request HealthBar creation and marks entity by HealthBarRequestedComponent 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    [Serializable]
    public sealed class HealthBarCreateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        
        private EcsFilter _filter;
        private EcsFilter _rootFilter;

        private HealthBarViewAspect _healthViewAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<HealthBarTargetComponent>()
                .Exc<HealthBarAssignedComponent>()
                .Exc<DestroyComponent>()
                .Exc<DisabledComponent>()
                .End();

            _rootFilter = _world
                .Filter<TransformComponent>()
                .Inc<HealthBarsRootComponent>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                foreach (var rootEntity in _rootFilter)
                {
                    var viewEntity = _world.NewEntity();
                    
                    ref var assignedComponent = ref _healthViewAspect.Assigned.GetOrAddComponent(entity);
                    ref var transformComponent = ref _healthViewAspect.Transform.Get(rootEntity);
                    
                    ref var ownerComponent = ref _healthViewAspect.Owner.Add(viewEntity);
                    ref var linkComponent = ref _healthViewAspect.HealthViewLink.Add(entity);

                    var viewPackedEntity = _world.PackEntity(viewEntity);
                    var ownerPackedEntity = _world.PackEntity(entity);

                    linkComponent.Entity = viewPackedEntity;
                    ownerComponent.Value = ownerPackedEntity;
                    
                    _world.MakeViewRequest(
                        typeof(HealthBarView),
                        ref viewPackedEntity,
                        ref ownerPackedEntity,
                        ViewType.None, 
                        transformComponent.Value);
                }
            }
        }
    }
}
