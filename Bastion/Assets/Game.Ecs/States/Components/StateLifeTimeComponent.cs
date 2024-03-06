namespace Game.Ecs.Server.Components
{
    using System;
    using Leopotam.EcsLite;
    using UniModules.UniCore.Runtime.DataFlow;

    /// <summary>
    /// lifetime of server state
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct StateLifeTimeComponent<TComponent> : IEcsAutoReset<StateLifeTimeComponent<TComponent>>
    {
        public LifeTimeDefinition LifeTime;
        
        public void AutoReset(ref StateLifeTimeComponent<TComponent> c)
        {
            c.LifeTime ??= new LifeTimeDefinition();
            c.LifeTime.Release();
        }
    }
}