namespace Game.Ecs.Network.Shared.Data
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Network Settings", fileName = "Network Settings")]
    public class NetworkSettingsAsset : ScriptableObject
    {
        [HideLabel]
        [InlineProperty]
        public NetworkSettings networkSettings = new();
    }
}