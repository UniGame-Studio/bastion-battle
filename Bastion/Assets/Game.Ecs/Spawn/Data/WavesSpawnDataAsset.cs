using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Ecs.Spawn.Data
{
    [CreateAssetMenu(menuName = "Game/Configurations/Spawn/Waves",fileName = nameof(WavesSpawnDataAsset))]
    public class WavesSpawnDataAsset : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public WavesSpawnData Data;
    }
}