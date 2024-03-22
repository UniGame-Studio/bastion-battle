namespace Game.Ecs.Ai.Navigation
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// Navigation feature for gameplay
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/NavigationFeature")]
    public class NavigationFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.Add(new SetDestinationToEnemySystem());

        }
    }
}