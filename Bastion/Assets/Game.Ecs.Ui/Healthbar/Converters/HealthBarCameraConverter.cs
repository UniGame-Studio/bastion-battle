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
    public sealed class HealthBarCameraConverter : GameObjectConverter
    {
        public Camera camera;
        protected override void OnApply(GameObject target, EcsWorld world, int entity)
        {
            ref var cameraComponent = ref world.GetOrAddComponent<HealthBarCameraComponent>(entity);
            cameraComponent.Camera = camera;
        }
    }
}