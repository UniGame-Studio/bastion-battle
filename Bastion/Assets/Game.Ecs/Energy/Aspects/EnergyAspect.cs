namespace Game.Ecs.Energy.Aspects
{
    using System;
    using Components;
    using Events;
    using Leopotam.EcsLite;
    using Requests;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// Aspect for energy 
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class EnergyAspect : EcsAspect
    {
        public EcsPool<EnergyComponent> Energy;
        //requests
        public EcsPool<AddEnergyRequest> AddRequest;
        public EcsPool<RemoveEnergyRequest> RemoveRequest;
        public EcsPool<SetEnergyRequest> SetRequest;
        //add 
        public EcsPool<NotEnoughEnergyEvent> NotEnough;
    }
}