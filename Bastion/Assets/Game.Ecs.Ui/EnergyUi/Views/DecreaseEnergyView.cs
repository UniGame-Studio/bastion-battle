namespace Game.Ecs.Ui.EnergyUi.Views
{
    using System;
    using Cysharp.Threading.Tasks;
    using Models;
    using UniGame.LeoEcs.ViewSystem.Converters;
    using UniGame.Rx.Runtime.Extensions;
    using UniGame.ViewSystem.Runtime;
    using UnityEngine.UI;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    /// <summary>
    /// BUTTON TO DECREASE ENERGY !! TEST
    /// </summary>
    [Serializable]
    public class DecreaseEnergyView : EcsUiView<RemoveEnergyViewModel>
    {
        public Button button;
        protected override UniTask OnInitialize(RemoveEnergyViewModel model)
        {
            this.Bind(button, model.removeEnergy);
            return base.OnInitialize(model);
        }

    }
}