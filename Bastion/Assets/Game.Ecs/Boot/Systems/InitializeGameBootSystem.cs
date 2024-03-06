namespace Girand.Ecs.GameSettings.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// game boot initializing
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class InitializeGameBootSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private SettingsAspect _settingsAspect;
        private GameBootAspect _bootAspect;
        
        private EcsFilter _settingsFilter;

        private ILifeTime _lifeTime;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _lifeTime = _world.GetWorldLifeTime();
            
            _settingsFilter = _world
                .Filter<GameSettingsComponent>()
                .Exc<GameAgentInitializedComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _settingsFilter)
            {
                ref var settingsComponent = ref _settingsAspect.GameSettings.Get(entity);
                var settings = settingsComponent.Value;

                ref var initializedComponent = ref _world
                    .AddComponent<GameAgentInitializedComponent>(entity);
            }
        }
    }
}