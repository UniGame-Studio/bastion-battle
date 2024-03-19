using System;
using System.Collections.Generic;
using Game.Ecs.Map.Components;
using Leopotam.EcsLite;
using Sirenix.OdinInspector;
using UniCore.Runtime.ProfilerTools;
using UniGame.LeoEcs.Converter.Runtime;
using UniGame.LeoEcs.Converter.Runtime.Abstract;
using UniGame.LeoEcs.Shared.Components;
using UniGame.LeoEcs.Shared.Extensions;
using UniGame.LeoEcsLite.LeoEcs.Shared.Components;
using UnityEngine;

namespace Game.Ecs.Map.Converters
{
    public class CellComponentMonoConverter : MonoLeoEcsConverter
    {
        public override void Apply(GameObject target, EcsWorld world, int entity)
        {
            var cellPool = world.GetPool<CellComponent>();
            ref var cell = ref cellPool.GetOrAddComponent(entity);

            cell.Position = target.transform;
        }
    }
}