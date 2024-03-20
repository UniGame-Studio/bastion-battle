namespace Game.Ecs.Ui.EnergyUi
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// Energy Ui Feature (display energy value)
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/EnergyUiFeature")]
    public class EnergyUiFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.Add(new GenerateChangeEnergyRequestSystem());//temp
            ecsSystems.Add(new UpdateEnergyUiSystem());
        }
    }
}