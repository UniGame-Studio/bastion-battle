namespace Game.Ecs.States.Views
{
    using System;
    using Cysharp.Threading.Tasks;
    using UniGame.LeoEcs.ViewSystem.Converters;
    using UniGame.Rx.Runtime.Extensions;
    using UnityEngine.UI;

#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    /// <summary>
    /// server commands ui view
    /// </summary>
    [Serializable]
    public class ServerCommandsView : EcsUiView<ServerCommandsViewModel>
    {
        public Button createHost;
        public Button stopHost;

        protected override UniTask OnInitialize(ServerCommandsViewModel model)
        {
            this.Bind(createHost, model.createHost)
                .Bind(stopHost, model.stopHost)
                .Bind(model.createHostAllowed, createHost)
                .Bind(model.stopHostAllowed, stopHost);
                
            return base.OnInitialize(model);
        }
    }
}