namespace Game.Ecs.UI.HealthBar.Config
{
    using Code.GameLayers.Layer;
    using UniModules.UniGame.Core.Runtime.DataStructure;
    using UnityEngine;

    [CreateAssetMenu(fileName = "LayerId Color Configuration",
        menuName = "Game/Configurations/Game Layers/LayerId Color Configuration")]
    public class LayerIdColorConfiguration : ScriptableObject
    {
        [SerializeField] private Color _defaultColor;

        [SerializeField]
        private SerializableDictionary<LayerId, Color> _layerIdColors = new SerializableDictionary<LayerId, Color>();

        public SerializableDictionary<LayerId, Color> LayerIdColors => _layerIdColors;

        public Color GetLayerIdColor(LayerId layerId)
        {
            if (_layerIdColors.TryGetValue(layerId, out var color))
                return color;

            return _defaultColor;
        }
    }
}