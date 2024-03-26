namespace Game.Ecs.Ui.EnergyUi.Models
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
    /// add energy button view model
    /// </summary>
    [Serializable]
    public class AddEnergyButtonViewModel : ViewModelBase
    {
        public SignalValueProperty<bool> addEnergy = new();
    }
}