namespace Game.Ecs.Ai
{
    using Ability.Tools;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    /// <summary>
    /// Group of features for gameplay units
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/UnitAiFeature", fileName = "Unit Ai Feature")]
    public class AiFeature : LeoEcsFeatureGroupAsset
    {
        AbilityTools abilityTools = new AbilityTools();
        protected override UniTask OnPostInitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            abilityTools.Init(ecsSystems);
            world.SetGlobal(abilityTools);
            //test
            // ecsSystems.Add(new TakeDamageByCooldownSystem());
            // ecsSystems.Add(new ApplyUnitsAbilitiesByCooldownSystem());
            ecsSystems.Add(new AttackTargetInMeleeRangeSystem());
            ecsSystems.Add(new DeathAfterMeleeAttackSystem());
            return base.OnPostInitializeFeatureAsync(ecsSystems);
        }
    }
}