namespace Girand.Ecs.GameSettings.Data
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Network/UnityNetcode Settings", fileName = "Unity Netcode Settings")]
    public class UnityNetcodeSettingsAsset : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public UnityNetcodeSettings settings = new();
    }
}