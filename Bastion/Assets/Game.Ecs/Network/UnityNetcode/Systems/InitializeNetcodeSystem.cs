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
    using Game.Ecs.Network.Shared.Data;
    using Leopotam.EcsLite;
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
    public class InitializeNetcodeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private NetworkAspect _networkAspect;
        private NetcodeAspect _netcodeAspect;
        
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsFilter _netFilter;
        
        private UnityNetcodeSettings _netcodeSettings;
        private NetworkSettings _networkSettings;
        private bool _isLoading;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _networkSettings = _world.GetGlobal<NetworkSettings>();
            _netcodeSettings = _world.GetGlobal<UnityNetcodeSettings>();
            
            _filter = _world
                .Filter<InitializeNetcodeSelfRequest>()
                .End();

            _netFilter = _world
                .Filter<NetworkSourceComponent>()
                .End();
        }

        public void Run(IEcsSystems systems)
        {
            var isExists = _netFilter.GetEntitiesCount() > 0;
            
            foreach (var entity in _filter)
            {
                if (isExists)
                {
                    _netcodeAspect.Initialize.Del(entity);
                    continue;
                }

                //network object in loading state
                if (_isLoading) continue;
                
                _isLoading = true;
                LoadNetcodeAgent().Forget();
            }
        }

        private async UniTask LoadNetcodeAgent()
        {
            var agentSource = _netcodeSettings.networkPrefab;
            var agent = await agentSource.LoadAssetInstanceTaskAsync(_world.GetWorldLifeTime(), true);
            Object.DontDestroyOnLoad(agent);
        }
    }
}