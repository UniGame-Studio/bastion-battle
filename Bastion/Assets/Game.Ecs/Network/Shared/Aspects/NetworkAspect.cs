namespace Game.Ecs.Network.Shared.Aspects
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// shared network aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class NetworkAspect : EcsAspect
    {
        public EcsPool<NetworkLinkComponent> NetworkLink;
        public EcsPool<NetworkSourceComponent> NetworkAgent;
        public EcsPool<NetworkHostComponent> Host;
        public EcsPool<NetworkClientComponent> Client;
        public EcsPool<NetworkAddressComponent> Address;
        
        //requests
        // link server to network transport
        public EcsPool<ConnectToHostSelfRequest> Connect;
        // create new host
        public EcsPool<CreateHostSelfRequest> CreateHost;
        public EcsPool<JoinRoomSelfRequest> JoinRoom;
    }
}