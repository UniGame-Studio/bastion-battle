namespace Game.Ecs.States
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [Serializable]
    [CreateAssetMenu(menuName = "Game/Tests/DemoSpawnFeature", fileName = "DemoSpawnFeature")]
    public class ServerUiFeature : BaseLeoEcsFeature 
    {
        public AssetReferenceGameObject unitDemoReference;
        
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            ecsSystems.Add(new ServerUiCommandsSystem(unitDemoReference));
            
            return  UniTask.CompletedTask;
        }
    }
    
}