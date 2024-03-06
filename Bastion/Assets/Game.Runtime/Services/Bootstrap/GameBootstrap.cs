namespace Game.Runtime.Services.Bootstrap
{
    using System;
    using System.Collections.Generic;
    using Cysharp.Threading.Tasks;
    using Runtime.Bootstrap;
    using UniCore.Runtime.ProfilerTools;
    using UniGame.AddressableTools.Runtime;
    using UniGame.Context.Runtime.DataSources;
    using UniGame.Core.Runtime;
    using UniModules.UniCore.Runtime.DataFlow;
    using UniModules.UniGame.Context.Runtime.Context;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public static class GameBootstrap
    {
        private static Dictionary<string, Func<ILifeTime, UniTask<bool>>> _bootStages
            = new()
            {
                { nameof(OnSetupAsync), OnSetupAsync },
                { nameof(InitializeAddressableAsync), InitializeAddressableAsync },
                { nameof(InitializeAsync), InitializeAsync },
            };

        private static LifeTimeDefinition _lifeTime;
        private static EntityContext _context;
        private static GameBootSettings _settings;

        public static ILifeTime LifeTime => _lifeTime;
        public static IContext Context => _context;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitializeGame()
        {
            InitializeInnerAsync().Forget();
        }

        public static void Restart()
        {
            InitializeInnerAsync().Forget();
        }


        public static void Dispose()
        {
            _lifeTime?.Terminate();
        }


        private static async UniTask<bool> InitializeAddressableAsync(ILifeTime lifeTime)
        {
            await Addressables.InitializeAsync();
            GameLog.LogRuntime("Addressable initialized");
            return true;
        }

        private static UniTask<bool> OnSetupAsync(ILifeTime lifeTime)
        {
            _lifeTime ??= new LifeTimeDefinition();
            _lifeTime.Release();
            _context = new EntityContext().AddTo(_lifeTime);

            return UniTask.FromResult(true);
        }

        private static async UniTask<bool> InitializeAsync(ILifeTime lifeTime)
        {
            var settingsAssetResult = await
                nameof(GameBootSettings)
                    .LoadAssetTaskAsync<GameBootSettings>(lifeTime)
                    .SuppressCancellationThrow();

            if (settingsAssetResult.IsCanceled)
                return false;

            var settingsAsset = settingsAssetResult.Result;
            var result = settingsAsset.Result;

            var source = await result.sources
                .LoadAssetInstanceTaskAsync<AsyncDataSources>(lifeTime, true);
            source.AddTo(lifeTime);

            await source.RegisterAsync(_context);

            return true;
        }

        private static async UniTask InitializeInnerAsync()
        {
            foreach (var stage in _bootStages)
            {
                var stageName = stage.Key;
                var stageFunc = stage.Value;

                Debug.Log($"Game Boot STAGE Execute: {stageName}");

                var stageResult = await stageFunc.Invoke(_lifeTime);
                if (!stageResult)
                {
                    Debug.LogError($"Game Boot STAGE ERROR: {stageName}");
                    return;
                }

                Debug.Log($"Game Boot STAGE Complete: {stageName}");
            }
        }
    }
}