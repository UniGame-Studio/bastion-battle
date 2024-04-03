namespace Game.Ecs.UI.HealthBar.Components
{
    using Leopotam.EcsLite;

    /// <summary>
    /// Stores HealthBar entity and marks when entity linked with HealthBar view
    /// </summary>
    public struct HealthBarLinkComponent
    {
        public EcsPackedEntity Entity;
    }
}