namespace Game.Runtime.Unit.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Sirenix.OdinInspector;
    using UnityEngine;

    /// <summary>
    /// Configuration asset for UnitId
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Configurations/Unit/UnitTypes Ids Configuration",
        fileName = "Game State Configuration")]
    public class UnitIdConfiguration : ScriptableObject
    {
        #region inspector

        [Header("default state")]
        [HideLabel]
        public UnitId defaultState;

        #endregion


        public List<string> ids= new List<string>();
    }
}