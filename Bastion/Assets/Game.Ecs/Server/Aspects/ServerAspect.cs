namespace Game.Ecs.Server.Aspects
{
    using System;
    using Components;
    using Components.Events;
    using Components.Requests;
    using Leopotam.EcsLite;
    using Network.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

    /// <summary>
    /// server agent aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ServerAspect : EcsAspect
    {
        public TimerAspect Timer;
        
        public EcsPool<ServerAgentComponent> ServerAgent;
        public EcsPool<ServerConnectedComponent> Connected;
        public EcsPool<ServerRoomComponent> Room;
        public EcsPool<ServerConfigurationComponent> Configuration;
        public EcsPool<ServerTickRateComponent> TickRate;
        public EcsPool<NameComponent> Name;
        public EcsPool<LifeTimeComponent> LifeTime;
        public EcsPool<NetworkAddressComponent> Address;
        
        public EcsPool<ServerSyncComponent> Sync;
        
        //requests
        public EcsPool<CreateServerSelfRequest> CreateServer;
        public EcsPool<CreateServerRoomSelfRequest> CreateRoom;
        
        //events
        public EcsPool<RoomReadyEvent> ReadyEvent;
    }
}