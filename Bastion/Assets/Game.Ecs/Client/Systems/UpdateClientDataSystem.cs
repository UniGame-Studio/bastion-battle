﻿namespace Game.Ecs.Client.Systems
{
    using System;
    using Aspects;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

    /// <summary>
    /// update local client data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class UpdateClientDataSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        
        private ClientAspect _clientAspect;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

        }

        public void Run(IEcsSystems systems)
        {
            
        }
    }
}