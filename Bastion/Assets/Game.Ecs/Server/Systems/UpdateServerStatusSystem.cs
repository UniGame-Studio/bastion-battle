namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;
    
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
    public class UpdateServerStatusSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private ServerAspect _serverAspect;
        private EcsFilter _serverFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _serverFilter = _world
                .Filter<ServerAgentComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var serverEntity in _serverFilter)
            {
                // var hasAgent = linkComponent.Value.Unpack(_world, out var photonEntity);
                // if (!hasAgent) continue;
                //
                // ref var statusComponent = ref _photonAspect.Status.Get(photonEntity);
                // ref var serverComponent = ref _serverAspect.ServerAgent.Get(serverEntity);
                //
                // serverComponent.IsConnected = statusComponent.IsConnected;
                // serverComponent.IsReady = statusComponent.IsOnMasterServer;
                // serverComponent.IsInRoom = statusComponent.IsInRoom;
                // serverComponent.IsMaster = statusComponent.IsMaster;
                //
                // if(statusComponent.IsConnected)
                //     _serverAspect.Connected.GetOrAddComponent(serverEntity);
                // else
                //     _serverAspect.Connected.TryRemove(serverEntity);
            }
        }
    }
}