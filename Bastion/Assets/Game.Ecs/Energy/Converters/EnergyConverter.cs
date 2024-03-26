namespace Game.Ecs.Energy.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// energy component converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class EnergyConverter : EcsComponentConverter
    {
        public float StartEnergy;
        public float MaxEnergy;
        public override void Apply(EcsWorld world, int entity)
        {
            ref var energyComponent = ref world.AddComponent<EnergyComponent>(entity);
            energyComponent.Energy = StartEnergy;
            energyComponent.MaxEnergy = MaxEnergy;
        }
    }
}