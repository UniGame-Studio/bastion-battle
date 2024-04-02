namespace Game.Ecs.Ai.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using JetBrains.Annotations;
    using Leopotam.EcsLite;
    using Sirenix.OdinInspector;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Converter.Runtime.Abstract;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;
    using UnityEngine.Serialization;

    /// <summary>
    /// Ai brain converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class AiBrainConverter : LeoEcsConverter, IEcsConverterProvider
    {
        [FormerlySerializedAs("Characteristics")]
        [ListDrawerSettings(ShowFoldout = true)]//OnBeginListElementGUI = nameof(BeginDrawListElement)
        [SerializeReference]
        [Required]
        [ItemNotNull]
        public List<LeoEcsConverter> aiConverters = new List<LeoEcsConverter>();

        
        [Button]
        public void ResetAll()
        {
            aiConverters.Clear();
            //harcode to add converters one by one
            aiConverters.Add(new AiMovementConverter());
        }
        
        public override void Apply(GameObject target, EcsWorld world, int entity)
        {
            foreach (var converter in Converters)
            {
                converter.Apply(world, entity);
            }
        }

        public IEnumerable<IEcsComponentConverter> Converters => aiConverters;
        public T GetConverter<T>() where T : class
        {
            foreach (var converter in Converters)
                if(converter is T result) return result;
            return null;
        }

        public void RemoveConverter<T>() where T : IEcsComponentConverter
        {
            throw new NotImplementedException();
        }

        public IEcsComponentConverter GetConverter(Type target)
        {
            foreach (var result in Converters)
            {
                if (result.GetType() == target)
                {
                    return result;
                }
            }
            return null;
        }
    }
}