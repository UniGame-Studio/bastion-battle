namespace Game.Ecs.Unit.Systems
{
    using System;
    using System.Linq;
    using Leopotam.EcsLite;
    using Requests;
    using UniGame.Core.Runtime.Extension;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// Handle unit spawn requests
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class SpawnUnitByRequestSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _requestFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _requestFilter = _world.Filter<SpawnUnitRequest>().End();
        }

        public void Run(IEcsSystems systems)
        {
            // get all spawn requests
            foreach (var request in _requestFilter)
            {
                //get prefab from map (service)
                //place at spawn point
                //add to team
                //remove request
            }
        }
    }
}