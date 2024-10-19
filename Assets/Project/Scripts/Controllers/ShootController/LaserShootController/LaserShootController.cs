using Assets.Project.Scripts.Infrastructure;
using Assets.Project.Scripts.Infrastructure.ControllersMapping.Attributes;
using Assets.Project.Scripts.Models.Weapon;

namespace Assets.Project.Scripts.Controllers.ShootController.LaserShootController
{
    [Controller]
    [ShootController(typeof(LaserWeapon))]

    public class LaserShootController
    {
    }
}
