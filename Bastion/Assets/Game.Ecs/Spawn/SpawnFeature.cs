using Game.Ecs.Spawn.Data.Events;
using Game.Ecs.Spawn.Systems;
using Leopotam.EcsLite.ExtendedSystems;
using UniGame.LeoEcs.Shared.Extensions;

namespace NAMESPACE
{
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UniGame.LeoEcs.Bootstrap.Runtime.Config;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/SpawnFeature")]
    public class SpawnFeature : BaseLeoEcsFeature
    {
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            ecsSystems.Add(new WavesInitSystem());
            
            // wave start
            ecsSystems.Add(new WaveStartSystem());
            ecsSystems.DelHere<WaveStartEvent>();
            ecsSystems.DelHere<WavesEndedEvent>();
            
            // wave delay 
            ecsSystems.Add(new WaveStartDelaySystem());
            ecsSystems.Add(new WaveEndDelaySystem());
            
            // wave duration
            ecsSystems.Add(new WaveStartDurationSystem());
            ecsSystems.Add(new WaveEndDurationSystem());
            
            // units spawn
            ecsSystems.Add(new UnitSpawnSystem());

            // next wave
            ecsSystems.Add(new WaveSwitchSystem());
            ecsSystems.DelHere<WaveEndEvent>();
        }
    }
}