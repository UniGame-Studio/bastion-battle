namespace Girand.Ecs.GameSettings.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Componenets.Requests;
    using Cysharp.Threading.Tasks;
    using Data;
    using Game.Ecs.Network.Shared.Aspects;
    using Game.Ecs.Network.Shared.Components;
    using Game.Ecs.Network.Shared.Components.Requests;
    using Game.Ecs.Network.Shared.Data;
    using Leopotam.EcsLite;
    using UniCore.Runtime.ProfilerTools;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Core.Runtime.Extension;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.Runtime.ObjectPool.Extensions;
    using UnityEngine;
    using UnityEngine.Pool;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using Object = UnityEngine.Object;

    /// <summary>
    /// initialize netcode data
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class CreateNetcodeHostSystem : IEcsInitSystem, IEcsRunSystem
    {
        private NetworkAspect _networkAspect;
        private NetcodeAspect _netcodeAspect;
        
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsFilter _netFilter;
        
        private bool _isLoading;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            
            _filter = _world
                .Filter<CreateHostSelfRequest>()
                .Exc<NetworkLinkComponent>()
                .Exc<InitializeNetcodeSelfRequest>()
                .End();

            _netFilter = _world
                .Filter<NetworkSourceComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                var netcodeEntity = -1;
                foreach (var netEntity in _netFilter)
                {
                    netcodeEntity = netEntity;
                    break;
                }
                
                if (netcodeEntity == -1)
                {
                    //ask for netcode initialization if non exists
                    _netcodeAspect.Initialize.Add(entity);
                    continue;
                }

                ref var createHostRequest = ref _networkAspect.CreateHost.Get(entity);
                
                ref var managerComponent = ref _netcodeAspect.Manager.Get(netcodeEntity);
                ref var transportComponent = ref _netcodeAspect.Transport.Get(netcodeEntity);

                var manager = managerComponent.Value;
                var transport = transportComponent.Value;
                
                transport.ConnectionData.Address = createHostRequest.Address;
                transport.ConnectionData.Port = createHostRequest.Port;
                
                //start host
                var result = manager.StartHost();
                if(!result)
                {
                    GameLog.LogError($"Failed to start host");
                    continue;
                }
                
                var packedNetEntity = _world.PackEntity(netcodeEntity);
                ref var linkComponent = ref _networkAspect.NetworkLink.GetOrAddComponent(entity);
                linkComponent.Value = packedNetEntity;
                
                //remove request as completed
                _networkAspect.CreateHost.Del(entity);
            }
        }

    }
}