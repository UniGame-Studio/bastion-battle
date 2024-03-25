using System;
using System.Collections.Generic;

namespace Game.Ecs.Spawn.Data
{
    [Serializable]
    public class WaveData
    {
        public float Delay;
        public float Duration;
        public List<UnitSpawnData> Units;
    }
}