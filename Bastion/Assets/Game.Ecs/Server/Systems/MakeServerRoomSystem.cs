namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components.Requests;
    using Data;
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
    public class MakeServerRoomSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;

        private ServerConfiguration _serverConfiguration;
        
        private ServerAspect _serverAspect;

        private EcsFilter _serverFilter;
        private EcsFilter _photonFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _serverConfiguration = _world.GetGlobal<ServerConfiguration>();
            
            _serverFilter = _world
                .Filter<CreateServerRoomSelfRequest>()
                .End();

        }

        public void Run(IEcsSystems systems)
        {
            
        }
    }
}