namespace Game.Ecs.Unit.Aspects
{
    using System;
    using Leopotam.EcsLite;
    using Requests;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;

    /// <summary>
    /// Shared aspect for unit components
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class UnitAspect : EcsAspect
    {
        //components
        
        //requests
        public EcsPool<SpawnUnitRequest> Request;
        
        //events
    }
}