namespace Game.Ecs.Energy
{
    using System;
    using Cysharp.Threading.Tasks;
    using Events;
    using Leopotam.EcsLite;
    using Leopotam.EcsLite.ExtendedSystems;
    using Requests;
    using Systems;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;

    /// <summary>
    /// Energy Feature. How player can get and spend energy
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Feature/Gameplay/EnergyFeature", fileName = "EnergyFeature")]
    public class EnergyFeature : BaseLeoEcsFeature
    {
        public EnergySettings Setup;
        public override async UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            var world = ecsSystems.GetWorld();
            // init system
            ecsSystems.Add(new InitializeEnergySystem(Setup));//в будущем переделать инициализацию энергии
            // add or remove energy
            ecsSystems.DelHere<NotEnoughEnergyEvent>();
            ecsSystems.Add(new SetEnergyValueSystem());
            ecsSystems.Add(new AddOrRemoveEnergySystem());
            
            ecsSystems.DelHere<SetEnergyRequest>();
            ecsSystems.DelHere<AddEnergyRequest>();
            ecsSystems.DelHere<RemoveEnergyRequest>();
        }
    }

    [Serializable]
    public struct EnergySettings
    {
        public int StartEnergy;
        public int MaxEnergy;
    }
}