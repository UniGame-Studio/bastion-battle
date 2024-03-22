namespace Game.Ecs.Ai.Navigation
{
    using Cysharp.Threading.Tasks;
    using Events;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using Unity.Mathematics;
    using UnityEngine;

    /// <summary>
    /// Navigation feature for gameplay
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/NavigationFeature")]
    public class NavigationFeature : BaseLeoEcsFeature
    {
        public Transform testEndPositionTransform;
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            float3 destination = testEndPositionTransform.position;
            ecsSystems.DelHere<DestinationIsReachedEvent>();
            //check distance by moving to target system
            // ecsSystems.Add(new MovingToTargetSystem());

            //set destination for all agents
            // ecsSystems.Add(new SetDestinationTestSystem(destination));
            ecsSystems.Add(new SetDestinationToEnemySystem());

        }
    }
}