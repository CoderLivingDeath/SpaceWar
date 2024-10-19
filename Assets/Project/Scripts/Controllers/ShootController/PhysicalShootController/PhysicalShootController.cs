using Assets.Project.Scripts.Infrastructure;
using Assets.Project.Scripts.Infrastructure.ControllersMapping;
using Assets.Project.Scripts.Infrastructure.ControllersMapping.Attributes;
using Assets.Project.Scripts.Models.Weapon;

namespace Assets.Project.Scripts.Controllers.ShootController.PhysicalShootController
{
    [Controller(LifeScopeEnum.Singlton)]
    [ShootController(typeof(PhysicalWeapon))]
    public class PhysicalShootController
    {

        public ShootResult Shoot(ShootContext context)
        {
            throw new System.Exception();
        }
    }
}
