using System.Collections.Generic;
using UnityEngine;

namespace Game.Ecs.Spawn.Data
{
    [CreateAssetMenu(menuName = "Game/Configurations/Spawn",fileName = nameof(WavesSpawnData))]
    public class WavesSpawnData : ScriptableObject
    {
        public List<WaveData> Waves;
    }
}