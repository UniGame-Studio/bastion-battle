namespace Girand.Ecs.GameSettings.Aspects
{
    using System;
    using Componenets;
    using Componenets.Requests;
    using Game.Ecs.Network.Shared.Aspects;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// netcode aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class NetcodeAspect : EcsAspect
    {
        public NetworkAspect Network;
        
        public EcsPool<NetworkManagerComponent> Manager;
        public EcsPool<NetcodeSharedRPCComponent> RPCAsset;
        public EcsPool<UnityTransportComponent> Transport;
        
        //requests
        //initialize netcode and create new entity if not exists
        public EcsPool<InitializeNetcodeSelfRequest> Initialize;
    }
}