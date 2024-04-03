using Game.Ecs.SetUnit.Data;
using Game.Ecs.SetUnit.Systems;
using UniGame.LeoEcs.Shared.Extensions;

namespace Game.Ecs.SetUnit
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/SetUnitFeature")]
    public class SetUnitFeature : BaseLeoEcsFeature
    {
        public CurrentCharactersSpawnDataAsset SpawnDataAsset;
        public override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.GetWorld().SetGlobal(SpawnDataAsset.Data);
            ecsSystems.Add(new MapUiCommandsSystem());

            return UniTask.CompletedTask;
        }
    }
}