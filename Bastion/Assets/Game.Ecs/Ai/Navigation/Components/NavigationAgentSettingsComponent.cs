namespace Game.Ecs.Ai.Navigation.Components
{
    using System;

    /// <summary>
    /// Settings for navigation agent in ECS
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct NavigationAgentSettingsComponent
    {
        public float speed;
        public float stoppingDistanceSqr;
    }
}