namespace Game.Ecs.Energy.Components
{
    using System;

    /// <summary>
    /// Players energy value and max energy value.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct EnergyComponent
    {
        public float Energy;
        public float MaxEnergy;
    }
}