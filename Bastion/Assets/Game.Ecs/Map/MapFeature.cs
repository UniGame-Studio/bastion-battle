using Cysharp.Threading.Tasks;
using Game.Ecs.Map.Requests;
using Game.Ecs.Map.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UniGame.LeoEcs.Bootstrap.Runtime;
using UnityEngine;

namespace Game.Ecs.Map
{
    [CreateAssetMenu(menuName = "Game/Feature/Game/Map", fileName = "Map Feature")]
    public class MapFeature : BaseLeoEcsFeature
    {
        public override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.DelHere<SetUnitOnMapRequest>();
            ecsSystems.Add(new SetUnitSystem());

            return UniTask.CompletedTask;
        }
    }
}