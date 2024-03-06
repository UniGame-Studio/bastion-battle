namespace Game.Ecs.Client.Data
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Client/Client Configuration Asset", 
        fileName = "Client Configuration Asset")]
    public class ClientConfigurationAsset : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public ClientConfiguration configuration = new ClientConfiguration();
    }
}