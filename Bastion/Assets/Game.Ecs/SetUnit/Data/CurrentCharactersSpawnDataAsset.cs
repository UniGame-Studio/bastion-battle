using UnityEngine;

namespace Game.Ecs.SetUnit.Data
{
    [CreateAssetMenu(menuName = "Game/Configurations/Spawn/Characters",fileName = nameof(CurrentCharactersSpawnDataAsset))]
    public class CurrentCharactersSpawnDataAsset : ScriptableObject
    {
        public CurrentCharactersSpawnData Data;
    }
}