namespace Game.Ecs.Ai
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UnityEngine;

    /// <summary>
    /// Group of features for gameplay units
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/UnitAiFeature", fileName = "Unit Ai Feature")]
    public class AiFeature : LeoEcsFeatureGroupAsset
    {
        protected override UniTask OnPostInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            //test
            ecsSystems.Add(new TakeDamageByCooldownSystem());
            return base.OnPostInitializeFeatureAsync(ecsSystems);
        }
    }
}