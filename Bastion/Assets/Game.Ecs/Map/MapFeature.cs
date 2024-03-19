using Cysharp.Threading.Tasks;
using Game.Ecs.Map.Requests;
using Game.Ecs.Map.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UniGame.LeoEcs.Bootstrap.Runtime;

namespace Game.Ecs.Map
{
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