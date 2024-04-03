    namespace Game.Ecs.UI.HealthBar.Converters
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UnityEngine;

    [Serializable]
    public sealed class HealthBarTargetConverter : MonoLeoEcsConverter
    {
        [SerializeField]
        private Transform _point;

        public override void Apply(GameObject target, EcsWorld world, int entity)
        {
            ref var targetComponent = ref world.AddComponent<HealthBarTargetComponent>(entity);

            targetComponent.Target = _point;
        }
    }
}