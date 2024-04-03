namespace Game.Code.UI.HealthBar
{
    using TMPro;
    using UnityEngine;

    public sealed class CharacteristicsView : MonoBehaviour
    {
        [SerializeField]
        private Color _baseColor = Color.white;
        [SerializeField]
        private Color _increaseColor = Color.green;
        [SerializeField]
        private Color _decreaseColor = Color.red;
        
        [SerializeField]
        private TextMeshProUGUI _adText;
        [SerializeField]
        private TextMeshProUGUI _apText;
        [SerializeField]
        private TextMeshProUGUI _armorText;
        [SerializeField]
        private TextMeshProUGUI _magicResistText;
        [SerializeField]
        private TextMeshProUGUI _speedText;
        [SerializeField]
        private TextMeshProUGUI _attackSpeedText;

        private float _ad;
        private float _ap;
        private float _armor;
        private float _magicResist;
        private float _speed;
        private float _attackSpeed;

        public void UpdateAd(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_ad, currentValue))
                return;

            _ad = currentValue;
            
            _adText.text = $"{Mathf.RoundToInt(currentValue)}";
            _adText.color = GetValueColor(baseValue, currentValue);
        }

        public void UpdateAp(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_ap, currentValue))
                return;

            _ap = currentValue;
            
            _apText.text = $"{Mathf.RoundToInt(currentValue)}";
            _apText.color = GetValueColor(baseValue, currentValue);
        }
        
        public void UpdateArmor(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_armor, currentValue))
                return;

            _armor = currentValue;
            
            _armorText.text = $"{Mathf.RoundToInt(currentValue)}";
            _armorText.color = GetValueColor(baseValue, currentValue);
        }
        
        public void UpdateMagicResist(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_magicResist, currentValue))
                return;

            _magicResist = currentValue;
            
            _magicResistText.text = $"{Mathf.RoundToInt(currentValue)}";
            _magicResistText.color = GetValueColor(baseValue, currentValue);
        }
        
        public void UpdateSpeed(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_speed, currentValue))
                return;

            _speed = currentValue;
            
            _speedText.text = $"{currentValue*100}";
            _speedText.color = GetValueColor(baseValue, currentValue);
        }
        
        public void UpdateAttackSpeed(float baseValue, float currentValue)
        {
            if(Mathf.Approximately(_attackSpeed, currentValue))
                return;

            _attackSpeed = currentValue;
            
            _attackSpeedText.text = $"{currentValue:0.00}";
            _attackSpeedText.color = GetValueColor(baseValue, currentValue);
        }

        private Color GetValueColor(float baseValue, float currentValue)
        {
            if (currentValue > baseValue)
                return _increaseColor;
            if (currentValue < baseValue)
                return _decreaseColor;
            return _baseColor;
        }
    }
}