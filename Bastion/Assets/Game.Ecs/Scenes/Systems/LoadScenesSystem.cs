namespace Game.Ecs.Client.Systems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Aspects;
    using Components.Events;
    using Components.Requests;
    using Cysharp.Threading.Tasks;
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
    public class LoadScenesSystem : 
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
                .Filter<LoadSceneByNameRequest>()
                .End();
        }
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _sceneFilter)
            {
                ref var loadRequest = ref _sceneAspect.LoadSceneByName.Get(entity);
                var sceneName = loadRequest.SceneName;

                var scene = SceneManager.GetSceneByName(sceneName);
                
                if(!loadRequest.Reload && scene.isLoaded) continue;
                
                LoadSceneAsync(loadRequest.SceneName,
                        loadRequest.LoadMode,
                        loadRequest.ActivateOnLoad).Forget();
            }
           
        }

        private async UniTask LoadSceneAsync(string sceneName,LoadSceneMode mode,bool activate)
        {
            await SceneManager.LoadSceneAsync(sceneName, mode);
            if (activate)
            {
                var sceneValue = SceneManager.GetSceneByName(sceneName);
                if (string.IsNullOrEmpty(sceneValue.name)) return;
                SceneManager.SetActiveScene(sceneValue);
            }
        }

    }
}