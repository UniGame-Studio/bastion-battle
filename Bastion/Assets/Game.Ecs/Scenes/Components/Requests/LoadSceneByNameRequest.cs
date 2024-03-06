namespace Game.Ecs.Client.Components.Requests
{
    using System;
    using UnityEngine.SceneManagement;
    using UnityEngine.Serialization;

    /// <summary>
    /// load new scene by name
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct LoadSceneByNameRequest
    {
        public string SceneName;
        public LoadSceneMode LoadMode;
        public bool ActivateOnLoad;
        public bool Reload;
    }
}