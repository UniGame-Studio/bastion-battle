namespace Game.Ecs.UI.HealthBar
{
    using Config;
    using Systems;
    using Cysharp.Threading.Tasks;
    using Leopotam.EcsLite;
    using UniGame.LeoEcs.Bootstrap.Runtime;
    using UnityEngine;
    
    //Для работы системы необходимо чтобы существовал CameraComponent который хранит ссылку на мейн камеру
    //И чтобы в канвасе лежал объект с HpbarRootComponent чтобы игра понимала куда его спавнить по иерархии

    [CreateAssetMenu(menuName = "Game/Feature/Ui/Health Bar Ui Feature", fileName = "Health Bar Ui Feature")]
    public sealed class HealthBarViewFeature : BaseLeoEcsFeature
    {
        [SerializeField] 
        public LayerIdColorConfiguration layerIdColor;
        
        public override UniTask InitializeFeatureAsync(IEcsSystems ecsSystems)
        {
            //make instance of healthBar color settings
            var colorSettings = Instantiate(layerIdColor);
            
            ecsSystems.Add(new HealthBarCreateSystem());
            // links HealthBarComponent owner entity and healthBar view entity, mark owner as linked
            // ecsSystems.Add(new HealthBarLinkSystem());
            // change healthBar color based it's relation to player entity
            ecsSystems.Add(new HealthBarColorSystem(colorSettings));
            
            // update healthBar shield data
            ecsSystems.Add(new HealthBarUpdateShieldSystem());
            // update healthBar data from owner entity
            ecsSystems.Add(new HealthBarUpdateSystem());
            
            // show and hides healthBars based on unit target
            ecsSystems.Add(new HealthBarUpdateSelectionTargetSystem());
            // show target of champions under the damage
            ecsSystems.Add(new HealthBarDisplayByDamageSystem());
            
            // TODO: move this system https://dreamfrost.atlassian.net/browse/IDLE-535
            ecsSystems.Add(new UpdateCharacteristicsViewSystem()); // why here?
            
            // destroy healthBar view when owner entity gone
            ecsSystems.Add(new HealthBarDestroySystem());
            //ecsSystems.Add(new HealthBarDestroyNotLinkedSystem());

            return UniTask.CompletedTask;
        }
    }
}
