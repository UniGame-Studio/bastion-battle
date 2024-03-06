namespace ExitGames.Client.Photon
{
    using System;
    using Game.Ecs.Client.Components.Requests;
    using Game.Ecs.NetworkCommands.Components.Events;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// send network message with rpc call
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class NetworkMessageRPCSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private NetworkCommandsToolsSystem _commandsTools;
        
        private RPCMessage[] _messages;
        private int _messagesCount;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _messagesCount = 0;
            _messages = new RPCMessage[1024];
            
            _commandsTools = _world.GetGlobal<NetworkCommandsToolsSystem>();

            _filter = _world
                .Filter<SendMessageRequest>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            for (int i = 0; i < _messagesCount; i++)
            {
                ref var message = ref _messages[i];
                ref var value = ref message.Value;
                var data = value.Value;
                
                switch (value.Code)
                {
                    //server
                    
                    case RPCMessageCodes.ToServerSelectCharacter:
                        _commandsTools.ReceiveEvent<ServerHeroSelectionEvent>(data);
                        break;
                    
                    //clients
                    
                    case RPCMessageCodes.ToPlayerHeroesSelection:
                        _commandsTools.ReceiveEvent<ToPlayerHeroesSelectionEvent>(data);
                        break;
                }
            }
            
            _messagesCount = 0;

            foreach (var messageEntity in _filter)
            {
            }
        }

    }
}