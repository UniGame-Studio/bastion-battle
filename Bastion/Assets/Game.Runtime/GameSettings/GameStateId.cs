namespace Game.Ecs.Game.Data
{
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;
    
#if UNITY_EDITOR
    using UniModules.Editor;
#endif
    
#if ENABLE_IL2CPP
    using System;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ValueDropdown("@Game.Ecs.Game.Data.GameStateId.GetStateIds()")]
    public partial struct GameStateId  : IEquatable<GameStateId>, IEquatable<int>
    {
        #region static data
        
        public static implicit operator int(GameStateId v)
        {
            return v.value;
        }

        public static explicit operator GameStateId(int v)
        {
            return new GameStateId { value = v };
        }
        
        public static explicit operator GameStateId(string v)
        {
            return new GameStateId
            {
                value = v.GetHashCode(),
                name = v,
            };
        }
        
        #endregion
        
        public int value;
        public string name;

        #region public methods
        
        public override string ToString() => value.ToString();

        public override int GetHashCode() => value;

        public GameStateId FromInt(int data)
        {
            value = data;
            return this;
        }

        public bool Equals(GameStateId other) => other.value == value;
        
        public bool Equals(int other) => other == value;

        public override bool Equals(object obj)
        {
            if (obj is GameStateId mask)
                return mask.value == value;
            
            return false;
        }
        
        #endregion
        
        #region editor api

#if ODIN_INSPECTOR
#if UNITY_EDITOR

        private static List<GameStatesAsset> _gameStatesAssets;
        
        public static IEnumerable<ValueDropdownItem<GameStateId>> GetStateIds()
        {
            _gameStatesAssets ??= AssetEditorTools.GetAssets<GameStatesAsset>();
            if(_gameStatesAssets == null)
                yield break;

            foreach (var asset in _gameStatesAssets)
            {
                var data = asset.gameStates;
                foreach (var state in data.gameStates)
                {
                    yield return new ValueDropdownItem<GameStateId>()
                    {
                        Text = state,
                        Value = (GameStateId)state,
                    };
                }
            }
        }

#endif
#endif
        

        
        #endregion
    }
}