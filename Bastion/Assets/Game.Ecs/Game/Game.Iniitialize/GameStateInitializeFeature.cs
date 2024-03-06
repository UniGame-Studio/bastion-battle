namespace Game.Ecs.State.Initialize
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime;

    [Serializable]
    public class GameStateInitializeFeature : LeoEcsFeature
    {
        protected sealed override UniTask OnInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var context = ecsSystems.GetShared<IContext>();
            
            //create game root entity
            ecsSystems.Add(new GameInitializeSystem());
            //load build type agents and assets
            ecsSystems.Add(new GameLoadBuildModeSystem());
            
            return UniTask.CompletedTask;
        }
    }
    
}