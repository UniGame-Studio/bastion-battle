namespace Game.Ecs.Player
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// Feature for player entity initialization
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/PlayerFeature")]
    public class PlayerFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
        }
    }
}