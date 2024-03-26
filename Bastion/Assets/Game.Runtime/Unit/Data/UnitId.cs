namespace Game.Runtime.Unit.Data
{
    using Unity.IL2CPP.CompilerServices;
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

#if UNITY_EDITOR
    using UniModules.Editor;
#endif


    /// <summary>
    /// UnitId is a unique identifier for a unit. Has a dropdown list in the inspector.
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    [ValueDropdown("@Game.Runtime.Unit.Data.UnitId.GetIds()")]
    public struct UnitId
    {
        [SerializeField]
        public string id;

        public string Id => id;

        public static implicit operator string(UnitId abilityId) => abilityId.Id;

        public static explicit operator UnitId(string abilityId) => new UnitId { id = abilityId };

        public override string ToString() => id;

        public override int GetHashCode() => string.IsNullOrEmpty(id)
            ? 0
            : id.GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is UnitId abilityId)
                return abilityId.Id == Id;

            return false;
        }

        public static IEnumerable<ValueDropdownItem<UnitId>> GetIds()
        {
#if UNITY_EDITOR

            var configuration = AssetEditorTools.GetAsset<UnitIdConfiguration>();
            foreach (var id in configuration.ids)
            {
                yield return new
                    ValueDropdownItem<UnitId>()
                    {
                        Text = id,
                        Value = (UnitId)id
                    };
            }

#endif

            yield break;
        }

    }
}