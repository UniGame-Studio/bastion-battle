namespace Game.Ecs.UI.HealthBar.Converters
{
    using System.Threading;
    using Code.UI.HealthBar;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    public sealed class CharacteristicViewMonoConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        public CharacteristicsView characteristicsView;
        
        public override void Apply(GameObject target, EcsWorld world, int entity)
        {
            ref var healthBar = ref world.AddComponent<CharacteristicsViewComponent>(entity);
            healthBar.View = characteristicsView;
        }
    }
}