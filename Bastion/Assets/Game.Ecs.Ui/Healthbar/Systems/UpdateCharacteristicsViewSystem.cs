namespace Game.Ecs.UI.HealthBar.Systems
{
    using Characteristics.Attack.Components;
    using Characteristics.Cooldown.Components;
    using Characteristics.Speed.Components;
    using Components;
    using Core.Components;
    using Ecs.Ability.Common.Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Timer.Components;

    public sealed class UpdateCharacteristicsViewSystem : IEcsRunSystem,IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsWorld _world;

        private EcsFilter _hudFilter;
        private EcsPool<CharacteristicsViewComponent> _hudViewPool;
        private EcsPool<AttackDamageComponent> _adPool;
        private EcsPool<SpeedComponent> _speedPool;
        private EcsPool<AbilityMapComponent> _abilityMapPool;
        private EcsPool<DefaultAbilityComponent> _defaultAbilityPool;
        private EcsPool<BaseCooldownComponent> _baseCooldownPool;
        private EcsPool<CooldownComponent> _cooldownPool;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<ChampionComponent>()
                .End();
            
            _hudFilter = _world.Filter<CharacteristicsViewComponent>().End();
            
            _hudViewPool = _world.GetPool<CharacteristicsViewComponent>();
            _adPool = _world.GetPool<AttackDamageComponent>();
            _speedPool = _world.GetPool<SpeedComponent>();
            _abilityMapPool = _world.GetPool<AbilityMapComponent>();
            _defaultAbilityPool = _world.GetPool<DefaultAbilityComponent>();
            _baseCooldownPool = _world.GetPool<BaseCooldownComponent>();
            _cooldownPool = _world.GetPool<CooldownComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var hudEntity in _hudFilter)
            {
                ref var hudView = ref _hudViewPool.Get(hudEntity);
                var characteristicsView = hudView.View;

                foreach (var entity in _filter)
                {
                    if (_adPool.Has(entity))
                    {
                        ref var ad = ref _adPool.Get(entity);
                        characteristicsView.UpdateAd(ad.Value, ad.Value);
                    }

                    if (_speedPool.Has(entity))
                    {
                        ref var speed = ref _speedPool.Get(entity);
                        characteristicsView.UpdateSpeed(speed.Value, speed.Value);
                    }

                    if (_abilityMapPool.Has(entity))
                    {
                        ref var abilityMap = ref _abilityMapPool.Get(entity);
                        foreach (var abilityPackedEntity in abilityMap.AbilityEntities)
                        {
                            if (!abilityPackedEntity.Unpack(_world, out var abilityEntity)
                                || !_defaultAbilityPool.Has(abilityEntity) || !_baseCooldownPool.Has(abilityEntity) || !_cooldownPool.Has(abilityEntity))
                                continue;

                            ref var baseCooldown = ref _baseCooldownPool.Get(abilityEntity);
                            ref var cooldown = ref _cooldownPool.Get(abilityEntity);

                            characteristicsView.UpdateAttackSpeed(1.0f / baseCooldown.Value, 1.0f / cooldown.Value);

                            break;
                        }
                    }
                }
            }
        }
    }
}