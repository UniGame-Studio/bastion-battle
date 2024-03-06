namespace Game.Ecs.Server.Data
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    /// <summary>
    /// server configuration asset
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Configurations/Server/Server Configuration Asset", fileName = "Server Configuration Asset")]
    public class ServerConfigurationAsset : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public ServerConfiguration configuration;
    }
}