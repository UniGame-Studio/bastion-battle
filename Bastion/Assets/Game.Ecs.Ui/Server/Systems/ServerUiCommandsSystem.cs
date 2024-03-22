namespace Game.Ecs.States.Systems
{
    using System;
    using GameResources.Aspects;
    using GameResources.Systems;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.Mathematics;
    using UnityEngine.AddressableAssets;

    /// <summary>
    /// update server ui commands
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class ServerUiCommandsSystem : IEcsInitSystem, IEcsRunSystem
    {
        public EcsWorld _world;
        public GameResourceAspect _resourceAspect;
        public AssetReferenceGameObject unitDemoReference;

        public int amount = 10;
        public GameSpawnTools _spawnTool;

        public ServerUiCommandsSystem(AssetReferenceGameObject unitDemoReference)
        {
            this.unitDemoReference = unitDemoReference;
        }
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _spawnTool = _world.GetGlobal<GameSpawnTools>();
        }

        public void Run(IEcsSystems systems)
        {
            if (amount <= 0) return;
            
            var guid = unitDemoReference.AssetGUID;
            var fakeOwner = _world.NewEntity();
            ref var transformPositionComponent = ref _world.AddComponent<TransformPositionComponent>(fakeOwner);
            var packedOwner = _world.PackEntity(fakeOwner);
            
            _spawnTool.Spawn(ref packedOwner,guid,float3.zero);

            amount--;
        }
    }
}