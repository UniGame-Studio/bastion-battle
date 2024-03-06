namespace Game.Ecs.Client.Components.Events
{
    using System;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// new scene loaded
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct SceneUnloadEvent
    {
        public Scene Scene;
    }
}