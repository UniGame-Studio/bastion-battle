namespace Game.Ecs.Client
{
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using Data;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Sirenix.OdinInspector;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Client/Game Client", fileName = "Game Client Feature")]
    public class GameClientFeature : BaseLeoEcsFeature
    {
        [HideLabel]
        public ClientConfigurationAsset clientConfiguration;

        public sealed override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            
            var settingsAsset = Object.Instantiate(clientConfiguration);
            var settings = settingsAsset.configuration;

            world.SetGlobal(settings);
            world.SetGlobal(settings.gameplayData);
            
            ecsSystems.Add(new ConnectClientSystem());
            ecsSystems.Add(new ConnectClientToRoomSystem());
            ecsSystems.Add(new UpdateClientDataSystem());
            
            ecsSystems.Add(new UpdateClientGameStateSystem());
            
            ecsSystems.DelHere<ConnectClientToRoomRequest>();
            
        }
    }

}