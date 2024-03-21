namespace Game.Ecs.Unit.Components
{
    using System;

    /// <summary>
    /// Mark entity as unit
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct UnitComponent
    {
        public int teamId;
    }
}