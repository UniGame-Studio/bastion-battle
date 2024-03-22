namespace Game.Ecs.Ai.Converter
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    /// <summary>
    /// Marks the class as a converter for the AiMovement component.
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class AiMovementConverter : LeoEcsConverter
    {
        public override void Apply(GameObject target, EcsWorld world, int entity)
        {
            world.GetPool<AiUnitMovementComponent>().Add(entity);
        }
    }
}