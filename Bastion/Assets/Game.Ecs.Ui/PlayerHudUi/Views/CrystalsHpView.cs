namespace Game.Ecs.Ui.PlayerHudUi.Views
{
    using System;
    using Cysharp.Threading.Tasks;
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
    /// Crystals hp view for player hud ui
    /// </summary>
    [Serializable]
    public class CrystalsHpView : EcsUiView<CrystalsHpViewModel>
    {
        public TextMeshProUGUI crystalsHpText;
        [SerializeField] public TweenSettings<float> tweenSettings;
        protected override UniTask OnInitialize(CrystalsHpViewModel model)
        {
            this.Bind(model.hp, UpdateText);
            return base.OnInitialize(model);
        }

        private void UpdateText(float value)
        {
            crystalsHpText.text = value.ToString();
            Tween.Scale(crystalsHpText.transform, tweenSettings);
        }
    }
}