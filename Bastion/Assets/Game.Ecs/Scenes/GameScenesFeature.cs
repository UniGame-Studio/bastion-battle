namespace Game.Ecs.Client
{
    using Components.Events;
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Unity/Game Scenes Feature", fileName = "Game Scenes Feature")]
    public class GameScenesFeature : BaseLeoEcsFeature
    {
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            ecsSystems.DelHere<SceneLoadedEvent>();
            ecsSystems.DelHere<SceneUnloadEvent>();
            
            ecsSystems.Add(new InitializeScenesSystem());
            
            ecsSystems.Add(new LoadScenesSystem());
            ecsSystems.Add(new ScenesEventsSystem());

            ecsSystems.DelHere<ActiveSceneChangedSelfEvent>();
            ecsSystems.Add(new UpdateActiveScenesSystem());

            ecsSystems.DelHere<LoadSceneByNameRequest>();
            
            return UniTask.CompletedTask;
        }
    }

}