namespace Girand.Ecs.GameSettings.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Leopotam.EcsLite;
    using Runtime.Services.GameSettings;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;

    /// <summary>
    /// initialize game settings system.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class InitializeGameSettingsSystem : IEcsInitSystem
    {
        private GameSettings _settings;
        private EcsWorld _world;

        private SettingsAspect _settingsAspect;

        public InitializeGameSettingsSystem(GameSettings settings)
        {
            _settings = settings;
        }
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            var entity = _world.NewEntity();
            ref var settingsComponent = ref _settingsAspect.GameSettings.Add(entity);
        }
    }
}