namespace Game.Ecs.Ui.EnergyUi.Views
{
    using System;
    using UniGame.Runtime.Common;
    using UniGame.UiSystem.Runtime;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    /// <summary>
    /// decrease energy view model
    /// </summary>
    [Serializable]
    public class DecreaseEnergyViewModel : ViewModelBase
    {
        public SignalValueProperty<bool> decreaseEnergy = new();
    }
}