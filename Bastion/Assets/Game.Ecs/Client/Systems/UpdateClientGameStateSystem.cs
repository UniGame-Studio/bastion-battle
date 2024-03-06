namespace Game.Ecs.Client.Systems
{
    using System;
    using Aspects;
    using Components;
    using Data;
    using Leopotam.EcsLite;
    using NetworkCommands.Components.Events;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Extensions;

    /// <summary>
    /// update local client data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateClientGameStateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private ClientConfiguration _configuration;
        
        private EcsFilter _clientFilter;
        private ClientAspect _clientAspect;
        private EcsFilter _eventFilter;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _configuration = _world
                .GetGlobal<ClientConfiguration>();
            
            _eventFilter = _world
                .Filter<GameStateEvent>()
                .End();
            
            _clientFilter = _world
                .Filter<ClientAgentComponent>()
                .Inc<ClientStateComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var stateEntity in _eventFilter)
            {

            }
            
        }
    }
}