namespace Game.Ecs.Ai.Navigation
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
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
            
            //check distance by moving to target system
            
            
            //stop at destination system
        }
    }
}