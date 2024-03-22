namespace Game.Runtime.Sources
{
    using Cysharp.Threading.Tasks;
    using UniGame.Context.Runtime;
    using UniGame.Core.Runtime;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Game/Sources/Boot Configuration Source", fileName = "BootConfigurationSource")]
    public class BootConfigurationSource : ScriptableObject, IAsyncDataSource
    {
        public UniTask<IContext> RegisterAsync(IContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
