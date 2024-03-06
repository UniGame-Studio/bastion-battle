namespace Game.Ecs.Client
{
    using Components.Requests;
    using Cysharp.Threading.Tasks;
    using ExitGames.Client.Photon;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using NetworkCommands.Components.Events;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Feature/Network/Game Network Commands Feature", fileName = "Game Network Commands Feature")]
    public class GameNetworkCommandsFeature : BaseLeoEcsFeature
    {
        public sealed override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            var tools = new NetworkCommandsToolsSystem();
            
            world.SetGlobal(tools);
            
            //remove events
            ecsSystems.DelHere<GameStateEvent>();
            ecsSystems.DelHere<ServerHeroSelectionEvent>();
            ecsSystems.DelHere<GameLobbyEvent>();
            
            //process network commands and create ecs data
            ecsSystems.Add(tools);
            ecsSystems.Add(new NetworkMessageRPCSystem());
            
            ecsSystems.DelHere<SendMessageRequest>();
            
            return UniTask.CompletedTask;
        }
    }

}