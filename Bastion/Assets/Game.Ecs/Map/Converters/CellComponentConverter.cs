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
            EcsPool<EmptyCellCountComponent> emptyCountPool = world.GetPool<EmptyCellCountComponent>();
            ref var cell = ref world.AddComponent<CellComponent>(entity);
            cell.IsEmply = true;
        }
    }
}