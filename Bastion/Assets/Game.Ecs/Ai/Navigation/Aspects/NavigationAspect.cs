namespace Game.Ecs.Ai.Navigation.Aspects
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// navigation aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class NavigationAspect : EcsAspect
    {
        public EcsPool<UnmovableComponent> Unmovable;
        public EcsPool<NavigationAgentComponent> NavigationAgent;
        public EcsPool<MoveToTargetComponent> MoveToTarget;
    }
}