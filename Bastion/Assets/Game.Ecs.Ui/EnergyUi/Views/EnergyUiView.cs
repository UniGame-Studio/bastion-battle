namespace Game.Ecs.Ui.EnergyUi.Views
{
    using System;
    using Cysharp.Threading.Tasks;
    using Models;
    using PrimeTween;
    using TMPro;
    using UniGame.LeoEcs.ViewSystem.Converters;
    using UniGame.Rx.Runtime.Extensions;
    using UnityEngine;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif

    /// <summary>
    /// energy ui view
    /// </summary>
    [Serializable]
    public class EnergyUiView : EcsUiView<EnergyUiViewModel>
    {
        public TextMeshProUGUI energyText;
        [SerializeField] public TweenSettings<float> tweenSettings;
        protected override UniTask OnInitialize(EnergyUiViewModel model)
        {
            this.Bind(model.energy, UpdateText);
            return base.OnInitialize(model);
        }
        
        
        private void UpdateText(float value)
        {
            energyText.text = value.ToString();
            Tween.Scale(energyText.transform, tweenSettings);
        }
    }
}