namespace Game.Ecs.Ai
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UnityEngine;

    /// <summary>
    /// Group of features for gameplay units
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/UnitFeature", fileName = "Unit Feature")]
    public class AiFeature : LeoEcsFeatureGroupAsset
    {
        protected override UniTask OnPostInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            return base.OnPostInitializeFeatureAsync(ecsSystems);
        }
    }
}