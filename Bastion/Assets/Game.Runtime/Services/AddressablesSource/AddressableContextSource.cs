namespace Game.Runtime.Services.AddressablesSource
{
    using Cysharp.Threading.Tasks;
    using Sirenix.OdinInspector;
    using UniGame.Context.Runtime;
    using UniGame.Core.Runtime;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Game/Services/Addressable Context Source", fileName = "Addressable Context Source")]
    public class AddressableContextSource : ScriptableObject,IAsyncDataSource
    {
        [InlineProperty]
        [HideLabel]
        public AddressableGameObjects source = new();

        public async UniTask<IContext> RegisterAsync(IContext context)
        {
            var lifeTime = context.LifeTime;
            await source.LoadAssets(lifeTime);
            return context;
        }
        
    }
}
