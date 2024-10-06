using Assets.Project.Scripts.Infrastructure;
using Assets.Project.Scripts.Models.Weapon;

namespace Assets.Project.Scripts.Controllers.ShootController.PhysicalShootController
{
    [ShootControllerTarget(typeof(PhysicalWeapon))]
    internal class PhysicalShootController : ShootController
    {
    }
}
