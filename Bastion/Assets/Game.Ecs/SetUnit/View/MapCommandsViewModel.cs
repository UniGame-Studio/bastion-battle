using System;
using UniGame.Runtime.Common;
using UniGame.UiSystem.Runtime;
using UniRx;

namespace Game.Ecs.SelectUnit.View
{
    [Serializable]
    public class MapCommandsViewModel : ViewModelBase
    {
        public SignalValueProperty<bool> AddUnitAction = new();
    }
}