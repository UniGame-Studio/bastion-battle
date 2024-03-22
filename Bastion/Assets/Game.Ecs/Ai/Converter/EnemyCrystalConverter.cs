namespace Game.Ecs.Ai.Converter
{
    using System;
    using System.Threading;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// ADD DESCRIPTION HERE
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class EnemyCrystalConverter : EcsComponentConverter
    {
        public override void Apply(EcsWorld world, int entity)
        {
            world.GetPool<EnemyCrystalComponent>().Add(entity);
        }
    }
}