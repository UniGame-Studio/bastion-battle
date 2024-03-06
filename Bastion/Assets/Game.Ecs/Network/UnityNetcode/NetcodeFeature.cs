namespace Girand.Ecs.GameSettings
{
    using Cysharp.Threading.Tasks;
    using Data;
    using Game.Ecs.Network.Shared.Data;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Systems;
    using UniGame.AddressableTools.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu(menuName = "Game/Feature/Network/Netcode Feature", fileName = "Netcode Feature")]
    public class NetcodeFeature : BaseLeoEcsFeature
    {
        public AssetReferenceT<UnityNetcodeSettingsAsset> netcodeSettings;
        public AssetReferenceT<NetworkSettingsAsset> networkSettings;
        
        public sealed override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var lifeTime = world.GetWorldLifeTime();
            
            var netcodeData = await netcodeSettings
                .LoadAssetInstanceTaskAsync(lifeTime, true);
            
            var networkData = await networkSettings
                .LoadAssetInstanceTaskAsync(lifeTime, true);

            //set global settings of network configuration
            world.SetGlobal(netcodeData.settings);
            world.SetGlobal(networkData.networkSettings);
            
            //create netcode host
            ecsSystems.Add(new CreateNetcodeHostSystem());
            //connect to netcode host as a client
            ecsSystems.Add(new ConnectToNetcodeHostSystem());
            //link request entity ot network agent
            ecsSystems.Add(new InitializeNetcodeSystem());
        }
    }

}