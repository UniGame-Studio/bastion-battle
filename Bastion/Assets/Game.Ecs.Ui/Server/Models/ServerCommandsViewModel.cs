namespace Game.Ecs.States.Views
{
    using System;
    using UniGame.Runtime.Common;
    using UniGame.UiSystem.Runtime;
    using UniModules.UniCore.Runtime.Common;
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    /// <summary>
    /// server ui model commands
    /// </summary>
    [Serializable]
    public class ServerCommandsViewModel : ViewModelBase
    {
        public SignalValueProperty<bool> createHost = new();
        public ReactiveValue<bool> createHostAllowed = new();
        public SignalValueProperty<bool> stopHost = new();
        public ReactiveValue<bool> stopHostAllowed = new();
    }
}