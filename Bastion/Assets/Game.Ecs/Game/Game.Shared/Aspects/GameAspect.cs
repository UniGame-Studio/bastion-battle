namespace Game.Ecs.Server.Aspects
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

    /// <summary>
    /// Game aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class GameAspect : EcsAspect
    {
        public EcsStateAspect<GameStateComponent> GameStateAspect;
        
        public EcsPool<GameRootComponent> GameRoot;
        public EcsPool<LifeTimeComponent> LifeTime;
        public EcsPool<StateComponent<GameStateComponent>> GameState;
    }
}