using System.Collections.Generic;
using Game.Ecs.Core.Components;
using Game.Ecs.Map.Aspects;
using Game.Ecs.Map.Components;
using UniGame.LeoEcs.Shared.Extensions;
using Unity.Collections;

namespace Game.Ecs.Map.Converters
{
    using System;
    using System.Threading;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    public class MapConvereter : EcsComponentConverter
    {
        public List<GameObject> Cells;
        
        public override void Apply(EcsWorld world, int entity)
        {
            world.GetOrAddComponent<EmptyCellCountComponent>(entity);
            ref var mapComponent = ref world.GetOrAddComponent<MapComponent>(entity);
            mapComponent.CellIds = new NativeHashSet<int>(Cells.Count, Allocator.Persistent);
            foreach (var cell in Cells)
            {
                mapComponent.CellIds.Add(cell.GetInstanceID());
            }
        }
    }
}