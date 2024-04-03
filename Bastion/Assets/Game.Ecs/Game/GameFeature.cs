namespace Game.Ecs.Server
{
    using Cysharp.Threading.Tasks;
    using GameLayers.Relationship;
    using States;
    using Girand.Ecs.GameSettings;
    using Leopotam.EcsLite;
    using State.Initialize;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Game/Game Feature", fileName = "Game Feature")]
    public class GameFeature : BaseLeoEcsFeature
    {
        public GameSettingsFeature gameSettingsFeature = new();
        public GameStatesFeature gameStatesFeature = new();
        public GameStateInitializeFeature gameStateInitializeFeature = new();
        public sealed override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            await gameSettingsFeature.InitializeFeatureAsync(ecsSystems);
            await gameStatesFeature.InitializeFeatureAsync(ecsSystems);
            await gameStateInitializeFeature.InitializeFeatureAsync(ecsSystems);
        }
    }
    
}