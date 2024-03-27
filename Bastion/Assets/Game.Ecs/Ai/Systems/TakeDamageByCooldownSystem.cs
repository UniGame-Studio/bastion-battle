namespace Game.Ecs.Ai.Systems
{
    using System;
    using Characteristics.Base.Components;
    using Characteristics.Health.Components;
    using Components;
    using Gameplay.Damage.Components.Request;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime.Abstract;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniGame.LeoEcs.Timer.Components;
    using UniGame.LeoEcs.Timer.Components.Events;
    using UniGame.LeoEcs.Timer.Components.Requests;
    using Unit.Components;

    /// <summary>
    /// Test system for take damage by cooldown
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class TakeDamageByCooldownSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter _enemyFilter;
        private TimerAspect _timerAspect;
        
        private EcsPool<CooldownComponent> _cooldownPool;
        private EcsFilter _endCooldownFilter;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _enemyFilter = _world.Filter<UnitComponent>()
                .Inc<HealthComponent>()
                .Exc<CooldownComponent>()
                .End();

            _endCooldownFilter = _world.Filter<UnitComponent>()
                .Inc<CooldownFinishedSelfEvent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var enemyEntity in _enemyFilter)
            {
                ref var cooldownComponent = ref _cooldownPool.Add(enemyEntity);
                cooldownComponent.Value = 5f;
                _world.GetPool<CooldownAutoRestartComponent>().Add(enemyEntity);
                _world.GetPool<RestartCooldownSelfRequest>().Add(enemyEntity);
            }

            foreach (var enemy in _endCooldownFilter)
            {
                var newEntity = _world.NewEntity();
                ref var damageComponent = ref _world.GetPool<ApplyDamageRequest>().Add(newEntity);
                damageComponent.Value = 2;
                damageComponent.Destination = _world.PackEntity(enemy);
            }
        }
    }
}