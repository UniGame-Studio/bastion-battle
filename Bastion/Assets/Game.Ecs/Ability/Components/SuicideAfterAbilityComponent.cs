namespace Game.Ecs.Ability.Components
{
    using System;

    /// <summary>
    /// Помечает сущность абилки, что ее владелец должен быть уничтожен после применения абилки.
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct SuicideAfterAbilityComponent
    {
        
    }
}