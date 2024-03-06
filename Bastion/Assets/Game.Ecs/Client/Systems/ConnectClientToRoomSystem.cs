﻿namespace Game.Ecs.Client.Systems
{
    using System;
    using Aspects;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// initialize game client
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ConnectClientToRoomSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;

        private ClientAspect _clientAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ConnectClientToRoomRequest>()
                .End();

        }

        public void Run(IEcsSystems systems)
        {
            foreach (var clientEntity in _filter)
            {

            }
        }
    }
}