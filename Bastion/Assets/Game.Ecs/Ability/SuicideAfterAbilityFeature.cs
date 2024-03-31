namespace Game.Ecs.Ability
{
    using Cysharp.Threading.Tasks;
    using Game.Ecs.Ability.SubFeatures;
    using Game.Ecs.Ability.Systems;
    using Leopotam.EcsLite;
    using UnityEngine;

    /// <summary>
    /// Сабфича, которая добавляет систему, которая убивает юнит после использования способности
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Ability/Suicide After Ability Feature", fileName = "Suicide After Ability Feature")]
    public class SuicideAfterAbilityFeature : AbilitySubFeature
    {
        public override UniTask<IEcsSystems> OnLastAbilitySystems(IEcsSystems ecsSystems)
        {
            ecsSystems.Add(new SuicideAfterAbilitySystem());
            return base.OnLastAbilitySystems(ecsSystems);
        }
    }
}