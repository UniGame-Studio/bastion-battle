namespace Game.Ecs.Ability.Effects
{
    using Components;
    using Game.Code.Configuration.Runtime.Ability.Description;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Shared.Extensions;

    public class SuicideAfterAbilityEffects : IAbilityBehaviour
    {
        public void Compose(EcsWorld world, int abilityEntity, bool isDefault)
        {
            var ecsPool = world.GetPool<SuicideAfterAbilityComponent>();
            ecsPool.GetOrAddComponent(abilityEntity);
        }
    }
}