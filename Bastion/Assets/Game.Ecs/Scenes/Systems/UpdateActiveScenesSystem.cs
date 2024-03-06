namespace Game.Ecs.Client.Systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aspects;
    using Components;
    using Components.Events;
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Pool;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// init scenes feature
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateActiveScenesSystem : 
        IEcsInitSystem, 
        IEcsRunSystem
    {
        private EcsWorld _world;
        private ScenesAspect _sceneAspect;
        
        private EcsFilter _sceneFilter;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _sceneFilter = _world
                .Filter<ActiveSceneComponent>()
                .Inc<HashComponent>()
                .Inc<NameComponent>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _sceneFilter)
            {
                ref var activeComponent = ref _sceneAspect.ActiveScene.Get(entity);
                ref var nameComponent = ref _sceneAspect.Name.Get(entity);
                ref var hashComponent = ref _sceneAspect.Hash.Get(entity);

                var activeScene = SceneManager.GetActiveScene();
                var hash = hashComponent.Value;

                var activeHash = activeScene.path.GetHashCode();
                if (activeHash == hash) continue;
                
                activeComponent.Value = activeScene;
                hashComponent.Value = activeHash;
                nameComponent.Value = activeScene.name;
                
                ref var activeSceneEvent = ref _sceneAspect.ActiveSceneChanged.Add(entity);
            }
           
        }


    }
}