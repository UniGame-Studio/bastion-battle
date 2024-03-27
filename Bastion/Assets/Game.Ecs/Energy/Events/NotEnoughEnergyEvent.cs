namespace Game.Ecs.Energy.Events
{
    using System;

    /// <summary>
    /// Event when player has not enough energy to perform action
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct NotEnoughEnergyEvent
    {
    }
}