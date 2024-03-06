namespace Game.Ecs.Server.Data
{
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Server States Asset", fileName = "Server States Asset")]
    public class ServerStatesAsset : ScriptableObject
    {
        [PropertySpace(8)]
        [FoldoutGroup("states")]
        [InlineProperty]
        [HideLabel]
        public ServerStatesData states = new ServerStatesData();
    }
}