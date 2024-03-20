using Cysharp.Threading.Tasks;
using Game.Ecs.Ability.Common.Components;
using Game.Ecs.Map.Requests;
using Game.Ecs.Map.Systems;
using Game.Ecs.Map.Tools;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UniGame.LeoEcs.Bootstrap.Runtime;
using UniGame.LeoEcs.Shared.Extensions;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;

namespace Game.Ecs.Map
{
    [CreateAssetMenu(menuName = "Game/Feature/Game/Map", fileName = "Map Feature")]
    public class MapFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            MapTools mapTools = new MapTools();
            world.SetGlobal(mapTools);
            
            ecsSystems.Add(mapTools);
            ecsSystems.DelHere<SetUnitOnMapRequest>();
            ecsSystems.Add(new SetUnitSystem());

            return UniTask.CompletedTask;
        }
    }
}