namespace Game.Ecs.Ai.Navigation.Components
{
    using System;
    using UnityEngine.AI;

    /// <summary>
    /// Navigation agent component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct NavigationAgentComponent
    {
        public NavMeshAgent agent;
    }
}