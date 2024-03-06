namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
    using Data;
    using Leopotam.EcsLite;
    using Network.Shared.Aspects;
    using Network.Shared.Data;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    ///   Initialize game server system.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class InitializeGameServerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private ServerAspect _serverAspect;
        private NetworkAspect _networkAspect;
        
        private EcsWorld _world;
        private EcsFilter _serverFilter;
        
        private ServerConfiguration _serverSettings;
        private NetworkSettings _networkSettings;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _serverSettings = _world.GetGlobal<ServerConfiguration>();
            _networkSettings = _world.GetGlobal<NetworkSettings>();

            _serverFilter = _world
                .Filter<ServerAgentComponent>()
                .Exc<ServerConfigurationComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _serverFilter)
            {
                ref var configurationComponent = ref _serverAspect.Configuration.GetOrAddComponent(entity);
                ref var nameComponent = ref _serverAspect.Name.GetOrAddComponent(entity);
                ref var tickRateComponent = ref _serverAspect.TickRate.GetOrAddComponent(entity);
                ref var lifeTimeComponent = ref _serverAspect.LifeTime.GetOrAddComponent(entity);
                ref var serverAddressComponent = ref _serverAspect.Address.GetOrAddComponent(entity);
                
                serverAddressComponent.Port = _networkSettings.serverPort;
                serverAddressComponent.Address = _networkSettings.serverAddress;
                tickRateComponent.TickRate = _serverSettings.tickRate;
                    
                configurationComponent.Version = _serverSettings.serverVersion;
                configurationComponent.ServerName = _serverSettings.serverName;
                configurationComponent.RoomMaxPlayers = _serverSettings.maxPlayers;
                nameComponent.Value = _serverSettings.serverName;

                if (_serverSettings.createHostAtStart)
                {
                    //start new host
                    ref var createHostRequest = ref _networkAspect.CreateHost.GetOrAddComponent(entity);
                    createHostRequest.Address = serverAddressComponent.Address;
                    createHostRequest.Port = serverAddressComponent.Port;
                }
                
            }
        }
    }
}