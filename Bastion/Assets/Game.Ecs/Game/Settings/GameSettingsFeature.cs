namespace Girand.Ecs.GameSettings
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Runtime.Services.GameSettings;
    using Sirenix.OdinInspector;
    using Systems;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine.AddressableAssets;

    [Serializable]
    public class GameSettingsFeature : LeoEcsFeature
    {
        [TitleGroup(nameof(settings))]
        [HideLabel]
        public AssetReferenceT<GameSettingsAsset> settings;
        
        protected sealed override async UniTask OnInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var lifeTime = world.GetWorldLifeTime();
            var context = ecsSystems.GetShared<IContext>();
            
            var settingsValue = await settings.LoadAssetInstanceTaskAsync(lifeTime,true);
            var settingsData = settingsValue.settings;
            var statesValue = settingsValue.gameStatesAsset;
            
            world.SetGlobal(statesValue.gameStates);
            world.SetGlobal(settingsData.gameMode);
            world.SetGlobal(settingsData);

            ecsSystems.Add(new InitializeGameSettingsSystem(settingsValue.settings));
        }
    }

}