namespace Game.Ecs.Ui.PlayerHudUi.Views
{
    using System;
    using UniGame.UiSystem.Runtime;
    using UniModules.UniGame.Core.Runtime.Rx;
    using UniRx;
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    /// <summary>
    /// model for crystals hp view
    /// </summary>
    [Serializable]
    public class CrystalsHpViewModel : ViewModelBase
    {
        public ReactiveValue<float> hp = new();
    }
}