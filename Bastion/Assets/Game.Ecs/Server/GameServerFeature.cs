namespace Game.Ecs.Server
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

    [CreateAssetMenu(menuName = "Game/Feature/Server/Game Server", fileName = "Game Server Feature")]
    public class GameServerFeature : BaseLeoEcsFeature
    {
        [HideLabel]
        public ServerConfigurationAsset serverConfiguration;
        
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var configuration = serverConfiguration.configuration;
            
            world.SetGlobal(configuration);
            
            ecsSystems.Add(new InitializeGameServerSystem()); 
            
            //base connection
            ecsSystems.Add(new UpdateServerStatusSystem());   
            
            ecsSystems.Add(new CheckRoomByConfigurationSystem()); 
            
            //create game room
            ecsSystems.Add(new MakeServerRoomSystem());
            ecsSystems.DelHere<CreateServerRoomSelfRequest>();
            
            //update players data
            
            ecsSystems.DelHere<CreateServerSelfRequest>();
            
            return UniTask.CompletedTask;
        }
    }
    
}