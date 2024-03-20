namespace Game.Ecs.States.Systems
{
    using System;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Shared.Components;

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
        private EcsWorld _world;
        private EcsFilter _asdasd;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _asdasd = _world.Filter<TransformComponent>().End();
        }

        public void Run(IEcsSystems systems)
        {
            
        }
    }
}