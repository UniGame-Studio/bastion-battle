namespace Game.Ecs.Unit.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// unit converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class UnitConverter : EcsComponentConverter
    {
        public override void Apply(EcsWorld world, int entity)
        {
            world.GetPool<UnitComponent>().Add(entity);
        }
    }
}