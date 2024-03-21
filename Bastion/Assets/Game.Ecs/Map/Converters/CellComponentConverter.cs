using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
using UniGame.LeoEcs.Converter.Runtime;
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
            EcsPool<ParentEntityComponent> parentPool = world.GetPool<ParentEntityComponent>();
            EcsPool<EmptyCellCountComponent> emptyCountPool = world.GetPool<EmptyCellCountComponent>();
            
            ref var parentComponent = ref parentPool.Get(entity); 
            
            ref var cell = ref world.AddComponent<CellComponent>(entity);
            cell.IsEmply = true;

            if (!parentComponent.Value.Unpack(world, out int parentMap)) return;

            ref var emptyCountComponent = ref emptyCountPool.Get(parentMap);
            emptyCountComponent.Count++;
        }
    }
}