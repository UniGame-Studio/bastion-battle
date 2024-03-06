namespace Game.Ecs.State.Initialize.Aspects
{
    using System;
    using Leopotam.EcsLite;
    using Server.Aspects;
    using Server.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;

    /// <summary>
    /// game initialize state aspect
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class GameInitAspect : EcsAspect
    {
        public EcsStateAspect<GameStateComponent> GameStateAspect;
        
        public EcsPool<LifeTimeComponent> LifeTime;
        public EcsPool<StateComponent<GameStateComponent>> GameState;
        
    }
}