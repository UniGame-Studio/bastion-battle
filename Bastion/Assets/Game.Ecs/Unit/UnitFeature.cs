namespace Game.Ecs.Unit
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UnityEngine;

    /// <summary>
    /// Group of features for gameplay units
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/UnitFeature", fileName = "Unit Feature")]
    public class UnitFeature : LeoEcsFeatureGroupAsset
    {
        protected override UniTask OnPostInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            //system Single Unit Spawn by Request
                
            return base.OnPostInitializeFeatureAsync(ecsSystems);
        }
    }
}