namespace Game.Ecs.Client.Aspects
{
    using System;
    using Components;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// client aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ClientAspect : EcsAspect
    {
        public ScenesAspect Scenes;
        
        public EcsPool<ClientAgentComponent> Client;
        public EcsPool<ClientStateComponent> State;
        
        //requests
        public EcsPool<ConnectClientToRoomRequest> Join;
    }
}