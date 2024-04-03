namespace Game.Ecs.UI.HealthBar.Components
{
    using System;

    /// <summary>
    /// Flag component to show that health bar displayed. If health bar is not displayed - you should remove component
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public struct HealthBarDisplayedComponent
    {
        
    }
}