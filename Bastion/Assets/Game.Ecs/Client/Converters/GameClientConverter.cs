namespace Game.Ecs.Client.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using Network.Shared.Components.Requests;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    /// <summary>
    /// game client converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class GameClientConverter : GameObjectConverter
    {
        protected override void OnApply(GameObject target, EcsWorld world, int entity)
        {
            ref var clientComponent = ref world.AddComponent<ClientAgentComponent>(entity);
        }

        
    }
}