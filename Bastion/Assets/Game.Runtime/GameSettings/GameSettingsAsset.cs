namespace Girand.Runtime.Services.GameSettings
{
    using Game.Ecs.Game.Data;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Game Settings", fileName = "Game Settings")]
    public class GameSettingsAsset : ScriptableObject
    {
        [TitleGroup("Game Settings")]
        [InlineProperty]
        [HideLabel]
        public GameSettings settings = new GameSettings();
        
        [TitleGroup("Game States")]
        [HideLabel]
        public GameStatesAsset gameStatesAsset;
    }


}