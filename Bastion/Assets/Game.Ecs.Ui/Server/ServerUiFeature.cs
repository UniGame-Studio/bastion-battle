namespace Game.Ecs.States
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime;

    [Serializable]
    public class ServerUiFeature : BaseLeoEcsFeature 
    {
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            
            
            return  UniTask.CompletedTask;
        }
    }
    
}