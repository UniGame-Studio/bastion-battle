namespace Game.Ecs.Server.Aspects
{
    using System;
    using Components;
    using Components.Events;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// generic state aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class EcsStateAspect<TComponent> : EcsAspect
        where TComponent : struct
    {
        //components
        
        /// <summary>
        /// current state
        /// </summary>
        public EcsPool<StateComponent<TComponent>> State;
        public EcsPool<StateLifeTimeComponent<TComponent>> LifeTime;
        public EcsPool<TComponent> Value;
        
        //requests
        
        /// <summary>
        /// request to apply new state to target
        /// </summary>
        public EcsPool<ApplyNewStateSelfRequest<TComponent>> ApplyState;
        public EcsPool<CreateStateSelfRequest<TComponent>> Create;
        
        
        //events
        
        /// <summary>
        /// notify about new state applied
        /// </summary>
        public EcsPool<StateChangedSelfEvent<TComponent>> OnNewState;
        public EcsPool<StateCreatedSelfEvent<TComponent>> OnCreate;
    }
}