namespace Game.Ecs.Game.Data
{
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Configurations/Game States Asset", fileName = "Game States Asset")]
    public class GameStatesAsset : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public GameStatesData gameStates = new();
    }

    [Serializable]
    public class GameStatesData
    {
        public GameStateId defaultState;
        
        public List<string> gameStates = new();
    }
}