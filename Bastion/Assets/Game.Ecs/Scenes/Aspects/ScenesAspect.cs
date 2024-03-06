namespace Game.Ecs.Client.Aspects
{
    using System;
    using Components;
    using Components.Events;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

    /// <summary>
    /// unity scene aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ScenesAspect : EcsAspect
    {
        public EcsPool<ActiveSceneComponent> ActiveScene;
        public EcsPool<NameComponent> Name;
        public EcsPool<HashComponent> Hash;
        
        //requests
        public EcsPool<LoadSceneByNameRequest> LoadSceneByName;
        
        //events
        public EcsPool<SceneLoadedEvent> SceneLoaded;
        public EcsPool<SceneUnloadEvent> SceneUnload;
        public EcsPool<ActiveSceneChangedSelfEvent> ActiveSceneChanged;
    }
}