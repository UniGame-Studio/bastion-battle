namespace Game.Ecs.Energy.Requests
{
    using System;
    using Leopotam.EcsLite;

    /// <summary>
    /// Request to change energy end value
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct SetEnergyRequest
    {
        public float Value;
        public float MaxValue;
        public EcsPackedEntity Entity; //можно оставлять пустым, т.к. в большинстве случаем источником будет игрок (нажал на кнопку, собрал предмет и т.д.)
    }
}