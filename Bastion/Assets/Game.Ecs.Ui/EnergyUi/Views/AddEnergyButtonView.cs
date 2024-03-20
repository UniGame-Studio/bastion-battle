namespace Game.Ecs.Ui.EnergyUi.Views
{
    using System;
    using Cysharp.Threading.Tasks;
    using Models;
    using UniGame.LeoEcs.ViewSystem.Converters;
    using UniGame.Rx.Runtime.Extensions;
    using UnityEngine.UI;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    /// <summary>
    /// Add energy button view
    /// </summary>
    [Serializable]
    public class AddEnergyButtonView : EcsUiView<AddEnergyButtonViewModel>
    {
        Button button;
        protected override UniTask OnInitialize(AddEnergyButtonViewModel model)
        {
            return base.OnInitialize(model);
        }
    }
}