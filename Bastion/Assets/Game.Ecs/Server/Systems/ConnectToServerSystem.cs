namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    
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
    public class ConnectToServerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _serverFilter;
        private ServerAspect _serverAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _serverFilter = _world
                .Filter<ServerAgentComponent>()
                .Inc<ServerConfigurationComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _serverFilter)
            {

            }
        }
    }
}