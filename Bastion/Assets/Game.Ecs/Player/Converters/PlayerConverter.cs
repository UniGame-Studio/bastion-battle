namespace Game.Ecs.Player.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using UniGame.LeoEcs.Shared.Extensions;
    using Unity.IL2CPP.CompilerServices;

    /// <summary>
    /// Player component converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class PlayerConverter : EcsComponentConverter
    {
        public override void Apply(EcsWorld world, int entity)
        {
            world.AddComponent<PlayerComponent>(entity);
        }
    }
}