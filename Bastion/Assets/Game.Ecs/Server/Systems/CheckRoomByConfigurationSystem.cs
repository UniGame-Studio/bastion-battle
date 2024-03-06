namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
    using Components.Requests;
    using Data;
    using Girand.Runtime.Services.GameSettings;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniModules.UniCore.Runtime.Extension;
    
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    /// <summary>
    /// Represents a system for creating and managing server rooms.
    /// </summary>
    [Serializable]
    [ECSDI]
    public class CheckRoomByConfigurationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private ServerAspect _serverAspect;
        
        private EcsFilter _serverFilter;
        
        private ServerConfiguration _serverConfiguration;
        private GameSettings _gameSettings;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _serverConfiguration = _world.GetGlobal<ServerConfiguration>();
            _gameSettings = _world.GetGlobal<GameSettings>();
            
            _serverFilter = _world
                .Filter<ServerAgentComponent>()
                .Inc<ServerConnectedComponent>()
                .Exc<CreateServerRoomSelfRequest>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {

        }
    }
}