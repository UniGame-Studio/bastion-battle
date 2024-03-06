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
    public class InitializeScenesSystem : 
        IEcsInitSystem, 
        IEcsRunSystem
    {
        private EcsWorld _world;
        private ScenesAspect _sceneAspect;
  
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            var entity = _world.NewEntity();
            
            ref var activeScene = ref _sceneAspect.ActiveScene.Add(entity);
            ref var nameComponent = ref _sceneAspect.Name.Add(entity);
            ref var hashComponent = ref _sceneAspect.Hash.Add(entity);
            var scene = SceneManager.GetActiveScene();
            
            var hash = scene.path.GetHashCode();
            activeScene.Value = scene;
            hashComponent.Value = hash;
            nameComponent.Value = scene.name;
        }
        
        public void Run(IEcsSystems systems)
        {
        }
    }
}