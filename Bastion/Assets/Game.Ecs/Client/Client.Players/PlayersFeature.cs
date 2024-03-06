namespace Girand.Ecs.Server
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Client/Client Players Feature", fileName = "Client Players Feature")]
    public class PlayersFeature : BaseLeoEcsFeature
    {
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            ecsSystems.Add(new InitializeClientPlayerSystem());
            
            return UniTask.CompletedTask;
        }
    }
    
}