namespace Game.Ecs.Ui.PlayerHudUi
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// feature for player hud ui (lives, and etc)
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Ui/PlayerHudUiFeature")]
    public class PlayerHudUiFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            //add systems here
            ecsSystems.Add(new UpdateCrystalHpSystem());
        }
    }
}