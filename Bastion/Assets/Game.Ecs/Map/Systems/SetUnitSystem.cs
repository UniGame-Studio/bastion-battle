using Leopotam.EcsLite;
using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;

namespace Game.Ecs.Map.Systems
{
    [ECSDI]
    public class SetUnitSystem : IEcsRunSystem, IEcsInitSystem
    {
        // private GameSpawnTools _gameSpawnTools;
            
        public void Init(IEcsSystems systems)
        {
            
        }
        
        public void Run(IEcsSystems systems)
        {
            // чекнуть эвент, что нужно установить юнита
            // запустить эвент, что нужно заспавнить юнита с позицией ячейки (спавн система)
        }
    }
}