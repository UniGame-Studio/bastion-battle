namespace Game.Ecs.Client.Converters
{
    using System;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    /// <summary>
    /// send to the work event about game state ready
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class GameStateReadyEventConverter : GameObjectConverter
    {
        protected override void OnApply(GameObject target,
            EcsWorld world, int entity)
        {
        }
        
    }
}