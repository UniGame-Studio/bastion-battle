using Game.Ecs.Spawn.Components;
using UniGame.LeoEcs.Shared.Components;

namespace NAMESPACE.Converters
{
    using System;
    using System.Threading;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [Serializable]
    public class SpawnPointConverter : EcsComponentConverter
    {
        public override void Apply(EcsWorld world, int entity)
        {
            ref var spawnPointComponent = ref world.GetPool<SpawnPointComponent>().Add(entity);
            ref var transformComponent = ref world.GetPool<TransformComponent>().Get(entity);
            spawnPointComponent.Position = transformComponent.Value.position;
        }
    }
}