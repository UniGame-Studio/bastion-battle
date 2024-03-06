namespace Girand.Ecs.GameSettings
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Game Boot Feature", fileName = "Game Boot Feature")]
    public class GameSettingsFeature : BaseLeoEcsFeature
    {
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            
            return UniTask.CompletedTask;
        }
    }

}