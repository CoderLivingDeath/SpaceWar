using Assets.Project.Scripts.Infrastructure;
using Assets.Project.Scripts.Models.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts.Controllers.ShootController.LaserShootController
{
    [ShootControllerTarget(typeof(LaserWeapon))]

    internal class LaserShootController : ShootController
    {
    }
}
