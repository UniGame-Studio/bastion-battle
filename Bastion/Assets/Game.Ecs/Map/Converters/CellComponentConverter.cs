using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Converter.Runtime;
using UniGame.LeoEcs.Shared.Components;
using UniGame.LeoEcs.Shared.Extensions;
using UniGame.LeoEcsLite.LeoEcs.Shared.Components;
using UnityEngine;

namespace Game.Ecs.Map.Converters
{
    [ECSDI]
    public class CellComponentConverter : EcsComponentConverter
    {
        public override void Apply(EcsWorld world, int entity)
        {
            EcsPool<GameObjectComponent> gameObjectsPool = world.GetPool<GameObjectComponent>();
            ref var cell = ref world.AddComponent<CellComponent>(entity);
            cell.IsEmply = true;
            
            ref var cellId = ref world.AddComponent<CellIdComponent>(entity);
            ref var gameObjectComponent = ref gameObjectsPool.Get(entity);
            cellId.Value = gameObjectComponent.Value.GetInstanceID();
        }
    }
}