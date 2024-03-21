namespace Game.Ecs.Ai.Navigation.Converters
{
    using System;
    using Components;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Converter.Runtime;
    using Unity.IL2CPP.CompilerServices;
    using UnityEngine.AI;

    /// <summary>
    /// Navigation converter
    /// </summary>
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public class NavigationConverter : EcsComponentConverter
    {
        public NavMeshAgent agent;
        public override void Apply(EcsWorld world, int entity)
        {
            var navAgentPool = world.GetPool<NavigationAgentComponent>();
            ref var navAgentComponent = ref navAgentPool.Add(entity);
            navAgentComponent.agent = agent;
        }
    }
}