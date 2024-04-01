namespace Game.Ecs.UI.HealthBar.Views
{
    using Cysharp.Threading.Tasks;
    using Models;
    using UniGame.LeoEcs.ViewSystem.Converters;
    using UniGame.Rx.Runtime.Extensions;
    using UnityEngine;
    using UnityEngine.Serialization;
    using UnityEngine.UI;

    public class HealthBarView : EcsUiView<HealthBarViewModel>
    {
        #region Inspector

        public Slider slider;
        public Image shieldImage;
        public CanvasGroup group;

        #endregion
        
        protected override UniTask OnInitialize(HealthBarViewModel model)
        {
            this.Bind(model.maxHealth, UpdateMaxHealth)
                .Bind(model.health, UpdateHealth)
                .Bind(model.shield, UpdateShield)
                .Bind(model.color, UpdateTeamColor)
                .Bind(model.isShow, group)
                .Bind(model.position, UpdatePosition);
            
            return base.OnInitialize(model);
        }

        private void UpdateTeamColor(Color color)
        {
            slider.fillRect.GetComponent<Image>().color = color;
        }
        
        private void UpdateMaxHealth(float maxHealth)
        {
            slider.maxValue = maxHealth;
        }

        private void UpdateHealth(float health)
        {
            slider.value = health;
        }

        private void UpdateShield(float shield)
        {
            var hasShield = shield > 0;
            
            shieldImage.enabled = hasShield;
            
            if(!hasShield)
                return;
            
            CalculateShieldRect(shield, out var xPosition, out var width);

            var shieldRectTransform = shieldImage.rectTransform;
            
            shieldRectTransform.localPosition = new Vector2(xPosition, shieldRectTransform.localPosition.y);
            shieldRectTransform.sizeDelta = new Vector2(width, shieldRectTransform.sizeDelta.y);
        }

        private void CalculateShieldRect(float shieldValue, out float xPosition, out float width)
        {
            var sliderRect = slider.transform as RectTransform;
            var fillRect = slider.fillRect;

            xPosition = fillRect.anchoredPosition.x + fillRect.rect.xMax;
            xPosition = Mathf.Clamp(xPosition, 0.0f, sliderRect.rect.width);

            width = (Mathf.Round(shieldValue) / slider.maxValue) * sliderRect.rect.width;

            if (xPosition + width > sliderRect.rect.width)
            {
                xPosition -= width;
            }

            xPosition -= sliderRect.rect.width;
        }

        private void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
    
}