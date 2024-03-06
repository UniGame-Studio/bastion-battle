namespace Game.Ecs.State.Initialize.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Cysharp.Threading.Tasks;
    using Game.Data;
    using Girand.Runtime.Services.GameSettings;
    using Leopotam.EcsLite;
    using UniGame.Core.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using UniGame.LeoEcs.Bootstrap.Runtime.Attributes;
    using UniModules.UniCore.Runtime.Extension;

    /// <summary>
    /// base initialization system for game
    /// </summary>
#if ENABLE_IL2CPP
    using Unity.IL2CPP.CompilerServices;

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [Serializable]
    [ECSDI]
    public class GameLoadBuildModeSystem : IEcsInitSystem
    {
        private GameInitAspect _gameInitAspect;
        
        private GameSettings _settings;
        private EcsWorld _world;
        private ILifeTime _lifeTime;
        private GameStatesData _statesData;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _lifeTime = _world.GetWorldLifeTime();
            _settings = _world.GetGlobal<GameSettings>();
            _statesData = _world.GetGlobal<GameStatesData>();
            
            InitializeGameMode(_settings.gameMode, _settings.gameModes).Forget();
            
            var stateEntity = _world.NewEntity();
            ref var createState = ref _gameInitAspect.GameStateAspect.Create.Add(stateEntity);
            createState.Value = _statesData.defaultState;
        }

        public async UniTask InitializeGameMode(BuildType mode,GameModeValue[] gameModes)
        {
            var tasks = gameModes
                .Where(x => mode.IsFlagSet(x.buildType))
                .Select(x => x.assets.LoadAssets(_lifeTime));

            await UniTask.WhenAll(tasks);
        }

    }
}