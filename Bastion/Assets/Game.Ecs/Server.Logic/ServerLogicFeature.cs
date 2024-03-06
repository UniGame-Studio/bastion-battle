namespace Game.Ecs.Server
{
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using States;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Server/Server Logic Feature", fileName = "Server Logic Feature")]
    public class ServerLogicFeature : BaseLeoEcsFeature
    {
        public ServerStatesFeature serverStatesFeature = new();
        
        public sealed override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.Add(new InitializeGameServerSystem()); 
            
            //add states support to server logic
            await serverStatesFeature.InitializeFeatureAsync(ecsSystems);

            //base connection
            ecsSystems.Add(new ConnectToServerSystem());    
            ecsSystems.Add(new UpdateServerStatusSystem());   
            
            ecsSystems.Add(new CheckRoomByConfigurationSystem()); 
            
            //create game room
            ecsSystems.Add(new MakeServerRoomSystem());
            ecsSystems.DelHere<CreateServerRoomSelfRequest>();
            
            //update players data

            ecsSystems.DelHere<CreateServerSelfRequest>();
        }
    }
    
}