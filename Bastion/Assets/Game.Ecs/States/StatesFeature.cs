namespace Game.Ecs.States
{
    using System;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Server.Components.Events;
    using Server.Components.Requests;
    using Server.Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;

    [Serializable]
    public class StatesFeature<TComponent> : LeoEcsFeature 
        where TComponent : struct
    {
        public virtual UniTask OnBeforeStateChanged(IEcsSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
        
        public virtual UniTask OnAfterStateChanged(IEcsSystems ecsSystems)
        {
            return UniTask.CompletedTask;
        }
        
        protected sealed override async UniTask OnInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();

            //remove last event
            ecsSystems.DelHere<StateChangedSelfEvent<TComponent>>();
            ecsSystems.DelHere<StateCreatedSelfEvent<TComponent>>();

            ecsSystems.Add(new CreateEcsStateSystem<TComponent>());
            
            await OnBeforeStateChanged(ecsSystems);
            
            //change state and fire new event
            ecsSystems.Add(new ChangeStateSystem<TComponent>());
            
            //remove last request to change state
            ecsSystems.DelHere<ApplyNewStateSelfRequest<TComponent>>();
            ecsSystems.DelHere<CreateStateSelfRequest<TComponent>>();

            //handle state change
            await OnAfterStateChanged(ecsSystems);
        }
    }
    
}