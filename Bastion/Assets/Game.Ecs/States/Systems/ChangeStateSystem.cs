namespace Game.Ecs.Server.Systems
{
    using System;
    using Aspects;
    using Components;
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
    public class ChangeStateSystem<TComponent> : IEcsInitSystem, IEcsRunSystem 
        where TComponent : struct
    {
        private EcsStateAspect<TComponent> _stateAspect;
        
        private EcsWorld _world;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _filter = _world
                .Filter<ApplyNewStateSelfRequest<TComponent>>()
                .Inc<StateComponent<TComponent>>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref var stateComponent = ref _stateAspect.State.Get(entity);
                
                ref var applyComponent = ref _stateAspect.ApplyState.Get(entity);
                
                var activeState = stateComponent.Value;
                var newState = applyComponent.Value;
                
                if(newState == activeState) continue;
                
                stateComponent.Value = newState;
                ref var stateEvent = ref _stateAspect.OnNewState.Add(entity);
                
                stateEvent.From = activeState;
                stateEvent.To = newState;
            }
        }
    }
}