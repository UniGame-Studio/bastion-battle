namespace Game.Ecs.Server.Data
{
    using System;
    using Sirenix.OdinInspector;

    [Serializable]
    public class ServerStateData
    {
        public string stateName = string.Empty;
        public string sceneName = string.Empty;

        [InlineProperty]
        public AddressableServerSource[] sceneObjects = Array.Empty<AddressableServerSource>();
    }
}