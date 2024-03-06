namespace Girand.Ecs.Server.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Components;
    using Game.Ecs.Client.Aspects;
    using Game.Ecs.Client.Components;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UnityEngine;
    using UnityEngine.Pool;

    /// <summary>
    /// add player to client agent
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class InitializeClientPlayerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private ClientAspect _clientAspect;
        private ClientPlayersAspect _playersAspect;
        
        private EcsWorld _world;
        
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world.Filter<ClientAgentComponent>()
                .Exc<LinkComponent<ClientPlayerComponent>>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var packedOwner = _world.PackEntity(entity);
                
                ref var playerLink = ref _playersAspect.PlayerLink.GetOrAddComponent(entity);
                
                var playerEntity = _world.NewEntity();
                var playerPacked = _world.PackEntity(playerEntity);
                
                ref var playerComponent = ref _playersAspect.Player.Add(playerEntity);
                ref var heroComponent = ref _playersAspect.Hero.Add(playerEntity);
                ref var ownerComponent = ref _playersAspect.Owner.Add(playerEntity);

                var guid = Guid.NewGuid().ToString();

                playerComponent.Name = guid;
                playerComponent.Token = guid;
                playerComponent.GUID = guid;
                
                ownerComponent.Value = packedOwner;
                playerLink.Value = playerPacked;
            }
        }
    }
}