namespace Game.Ecs.Client.Systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aspects;
    using Components.Events;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
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
    public class ScenesEventsSystem : IEcsInitSystem, 
        IEcsRunSystem,
        IEcsDestroySystem
    {
        private EcsWorld _world;
        private ScenesAspect _sceneAspect;
        private EcsFilter _sceneFilter;
        
        private List<SceneLoadedEvent> _loadedScenes = new List<SceneLoadedEvent>();
        private List<Scene> _unloadedScenes = new List<Scene>();
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _sceneFilter = _world
                .Filter<LoadSceneByNameRequest>()
                .End();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        public void Destroy(IEcsSystems systems)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
        
        public void Run(IEcsSystems systems)
        {
            var activeScene = SceneManager.GetActiveScene();

            foreach (var sceneValue in _loadedScenes)
            {
                var sceneEvent = _world.NewEntity();
                ref var sceneLoaded = ref _sceneAspect.SceneLoaded.Add(sceneEvent);

                var scene = sceneLoaded.Scene;
                var isActive = scene.handle == activeScene.handle;
                    
                sceneLoaded.Scene = scene;
                sceneLoaded.IsActive = isActive;
                sceneLoaded.Mode = sceneValue.Mode;
            }

            foreach (var unloadedScene in _unloadedScenes)
            {
                var sceneEvent = _world.NewEntity();
                ref var unloadEvent = ref _sceneAspect.SceneUnload.Add(sceneEvent);
                unloadEvent.Scene = unloadedScene;
            }
                
            _loadedScenes.Clear();
            _unloadedScenes.Clear();
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            var sceneLoaded = new SceneLoadedEvent()
            {
                Scene = scene,
                Mode = mode
            };
            
            _loadedScenes.Add(sceneLoaded);
        }

        private void OnSceneUnloaded(Scene scene)
        {
            _unloadedScenes.Add(scene);
        }

    }
}