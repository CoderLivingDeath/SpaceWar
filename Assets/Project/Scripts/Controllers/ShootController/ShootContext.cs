using Assets.Project.Scripts.Models.Weapon;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.ShootController
{
    public class ShootContext
    {
        // вид боеприпаса, вид оружия
        public WeaponBase Weapon;
        public Vector2 SpawnPoint;
        public Vector2 ShootDirection;
    }
}