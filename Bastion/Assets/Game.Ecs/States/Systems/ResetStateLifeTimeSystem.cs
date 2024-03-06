namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
    using Components.Events;
    using Components.Requests;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// setup new state for ecs world
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ResetStateLifeTimeSystem<TComponent> : IEcsInitSystem, IEcsRunSystem 
        where TComponent : struct
    {
        private EcsStateAspect<TComponent> _stateAspect;
        
        private EcsWorld _world;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<StateChangedSelfEvent<TComponent>>()
                .Exc<StateLifeTimeComponent<TComponent>>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var lifeTimeComponent = ref _stateAspect.LifeTime.Add(entity);
                lifeTimeComponent.LifeTime.Release();
            }
        }
    }
}