namespace Game.Ecs.UI.HealthBar.Systems
{
    using System.Collections.Generic;
    using System.Linq;
    using Ability.SubFeatures.Target.Components;
    using Core.Components;
    using Input.Components;
    using Leopotam.EcsLite;
    using Models;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.ViewSystem.Components;
    using UniGame.LeoEcs.ViewSystem.Extensions;
    using UnityEngine.Pool;
    
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
    public sealed class HealthBarUpdateSelectionTargetSystem : IEcsRunSystem,IEcsInitSystem
    {
        private EcsFilter _filterHealthBars;
        private EcsWorld _world;
        private List<int> _unpackBuffer;
        
        private EcsPool<UnderTheTargetComponent> _underTargetPool;
        private EcsPool<OwnerComponent> _ownerPool;
        private EcsPool<UserInputTargetComponent> _userInputPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filterHealthBars = _world
                .ViewFilter<HealthBarViewModel>()
                .Inc<OwnerComponent>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var healthBarEntity in _filterHealthBars)
            {
                if (!_world.TryGetViewModel(healthBarEntity, out HealthBarViewModel healthBarViewModel))
                    continue;
                
                ref var ownerLink = ref _ownerPool.Get(healthBarEntity);
                if (!ownerLink.Value.Unpack(_world, out var ownerEntity))
                    continue;

                if (_userInputPool.Has(ownerEntity))
                    healthBarViewModel.isShow.Value = true;
            }
        }
    }
}