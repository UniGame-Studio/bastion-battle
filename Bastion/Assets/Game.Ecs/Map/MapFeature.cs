using Cysharp.Threading.Tasks;
using Game.Ecs.Ability.Common.Components;
using Game.Ecs.Map.Requests;
using Game.Ecs.Map.Systems;
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
            // map
            ecsSystems.Add(new MapAndCellsConnectSystem());
            
            // set on random cell
            ecsSystems.Add(new SetOnRandomCellSystem());
            ecsSystems.DelHere<SetOnRandomCellRequest>();
            
            // set on concrete cel
            ecsSystems.Add(new SetOnCellSystem());
            ecsSystems.DelHere<SetOnCellRequest>();

            return UniTask.CompletedTask;
        }
    }
}