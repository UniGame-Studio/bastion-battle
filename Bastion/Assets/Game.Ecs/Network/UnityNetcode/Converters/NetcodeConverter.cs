namespace Girand.Ecs.GameSettings.Converters
{
    using System;
    using Componenets;
    using Game.Ecs.Network.Shared.Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;
    using Unity.Netcode;
    using Unity.Netcode.Transports.UTP;
    using UnityEngine;

    /// <summary>
    /// converter for netcode prefab to ecs world
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class NetcodeConverter : GameObjectConverter
    {
        public NetworkManager networkManager;
        public UnityTransport unityTransport;
        
        protected override void OnApply(GameObject target, EcsWorld world, int entity)
        {
            ref var networkManagerComponent = ref world.GetOrAddComponent<NetworkManagerComponent>(entity);
            networkManagerComponent.Value = this.networkManager;

            ref var unityTransportComponent = ref world.GetOrAddComponent<UnityTransportComponent>(entity);
            unityTransportComponent.Value = this.unityTransport;
            
            ref var targetComponent = ref world.GetOrAddComponent<NetcodeSharedRPCComponent>(entity);
            targetComponent.Value = target;
            
            ref var networkSourceComponent = ref world.GetOrAddComponent<NetworkSourceComponent>(entity);
        }

        
    }
}