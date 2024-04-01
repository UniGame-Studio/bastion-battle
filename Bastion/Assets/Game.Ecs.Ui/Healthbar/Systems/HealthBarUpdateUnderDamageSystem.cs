namespace Game.Ecs.UI.HealthBar.Systems
{
    using System.Collections.Generic;
    using Ability.Common.Components;
    using Ability.SubFeatures.Target.Components;
    using Ability.Tools;
    using Components;
    using Core.Components;
    using Input.Components;
    using Leopotam.EcsLite;
    using Models;
    using TargetSelection;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.ViewSystem.Extensions;

    /// <summary>
    /// Show and Hides HealthBars based on UnderTheTargetComponent 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [ECSDI]
    public sealed class HealthBarUpdateUnderDamageSystem : IEcsRunSystem,IEcsInitSystem
    {
        private AbilityTools _abilityTools;
        private EcsWorld _world;
        
        private EcsFilter _filterHealthBars;
        private EcsFilter _targetFilter;
        
        private EcsPool<OwnerComponent> _ownerPool;
        private EcsPool<UserInputTargetComponent> _userInputPool;
        private EcsPool<HealthBarTargetComponent> _healthTargetPool;
        private EcsPool<AbilityTargetsComponent> _targetsPool;
        private EcsPool<PrepareToDeathComponent> _prepareToDeathPool;

        private EcsPackedEntity[] _damageTargets = new EcsPackedEntity[TargetSelectionData.MaxTargets];

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _abilityTools = _world.GetGlobal<AbilityTools>();
            
            _filterHealthBars = _world
                .ViewFilter<HealthBarViewModel>()
                .Inc<OwnerComponent>()
                .End();

            _targetFilter = _world
                .Filter<AbilityMapComponent>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            var targetCounter = 0;
            
            foreach (var targetEntity in _targetFilter)
            {
                if(targetCounter >= TargetSelectionData.MaxTargets) break;
                
                if(!_abilityTools.TryGetDefaultAbility(_world,targetEntity,out var abilityEntity))
                    continue;
                
                ref var targetsComponent = ref _targetsPool.Get(abilityEntity);

                for (var i = 0; i < targetsComponent.Count; i++)
                {
                    if(targetCounter >= TargetSelectionData.MaxTargets) break;
                    _damageTargets[targetCounter] = targetsComponent.Entities[i];
                    targetCounter++;
                }
            }
            
            if(targetCounter <= 0) return;
            
            var found = false;

            for (int i = 0; i < targetCounter; i++)
            {
                ref var target = ref _damageTargets[i];
                
                foreach (var healthBarEntity in _filterHealthBars)
                {
                    ref var ownerComponent = ref _ownerPool.Get(healthBarEntity);
                    if (!ownerComponent.Value.Unpack(_world, out var ownerEntity))
                        continue;

                    if(_userInputPool.Has(ownerEntity)) continue;
                    
                    var visibility = ownerComponent.Value.EqualsTo(target);
                    found |= visibility;
                    
                    if (!_world.TryGetViewModel(healthBarEntity, out HealthBarViewModel healthBarViewModel))
                        continue;
                
                    healthBarViewModel.isShow.Value = visibility;
                }

                if (found) break;
            }
            
            
        }
    }
}