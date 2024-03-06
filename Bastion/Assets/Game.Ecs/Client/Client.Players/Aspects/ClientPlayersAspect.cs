namespace Girand.Ecs.Server.Aspects
{
    using System;
    using Components;
    using Components.Events;
    using Game.Ecs.Client.Components.Requests;
    using Game.Ecs.Core.Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Shared.Components;

    /// <summary>
    /// network players aspect data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class ClientPlayersAspect : EcsAspect
    {
        public EcsPool<ClientPlayerComponent> Player;
        public EcsPool<ClientHeroComponent> Hero;
        public EcsPool<ClientHeroLockedComponent> HeroLocked;
        public EcsPool<OwnerComponent> Owner;

        public EcsPool<LinkComponent<ClientPlayerComponent>> PlayerLink;
        
        //requests
        
        //events
        public EcsPool<ClientHeroSelectedSelfEvent> HeroSelected;
    }
}