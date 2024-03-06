namespace Game.Ecs.Server.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcsLite.LeoEcs.Shared.Components;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    /// <summary>
    /// add base server agent components to entity
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class GameServerConverter : GameObjectConverter
    {
        protected override void OnApply(GameObject target, EcsWorld world, int entity)
        {
            ref var serverActor = ref world.GetOrAddComponent<ServerAgentComponent>(entity);
        }
    }
}