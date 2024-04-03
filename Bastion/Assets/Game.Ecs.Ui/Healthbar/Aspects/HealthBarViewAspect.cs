namespace Game.Ecs.UI.HealthBar.Aspects
{
    using System;
    using Components;
    using Core.Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    [Serializable]
    public class HealthBarViewAspect : EcsAspect
    {
        public EcsPool<HealthBarTargetComponent> HealthBarTarget;
        public EcsPool<TransformComponent> Transform;
        public EcsPool<HealthBarLinkComponent> HealthViewLink;
        public EcsPool<OwnerComponent> Owner;
        
        public EcsPool<HealthBarAssignedComponent> Assigned;
    }
}