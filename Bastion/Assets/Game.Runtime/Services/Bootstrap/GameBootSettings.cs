namespace Game.Runtime.Bootstrap
{
    using UniGame.Context.Runtime.DataSources;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu(menuName = "Game/Configurations/GameBootSettings", fileName = nameof(GameBootSettings))]
    public class GameBootSettings : ScriptableObject
    {
        public AssetReferenceT<AsyncDataSources> sources;
    }
}