using Cysharp.Threading.Tasks;
using UniGame.LeoEcs.ViewSystem.Converters;
using UniGame.Rx.Runtime.Extensions;
using UnityEngine.UI;

namespace Game.Ecs.SetUnit.View
{
    public class MapCommandsView : EcsUiView<MapCommandsViewModel>
    {
        public Button addUnitAction;

        protected override UniTask OnInitialize(MapCommandsViewModel model)
        {
            this.Bind(addUnitAction, model.AddUnitAction);
            
            return base.OnInitialize(model);
        }
    }
}