namespace Game.Ecs.Energy.Requests
{
    using System;
    using Leopotam.EcsLite;

    /// <summary>
    /// request to remove energy value from player energy
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct RemoveEnergyRequest
    {
        public float Value;
        public EcsPackedEntity Source;
    }
}