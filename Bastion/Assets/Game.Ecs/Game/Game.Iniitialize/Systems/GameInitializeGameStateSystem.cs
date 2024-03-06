namespace Game.Ecs.State.Initialize.Systems
{
    using System;
    using System.Linq;
    using Aspects;
    using Cysharp.Threading.Tasks;
    using Game.Data;
    using Girand.Runtime.Services.GameSettings;
    using Leopotam.EcsLite;
    using Server.Aspects;
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
    public class GameInitializeSystem : IEcsInitSystem
    {
        private GameAspect _gameAspect;
        
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

            var stateEntity = _world.NewEntity();
            ref var rootComponent = ref _gameAspect.GameRoot.Add(stateEntity);
            ref var lifeTimeComponent = ref _gameAspect.LifeTime.Add(stateEntity);
            ref var createState = ref _gameAspect.GameStateAspect.Create.Add(stateEntity);
            createState.Value = _statesData.defaultState;
        }

    }
}