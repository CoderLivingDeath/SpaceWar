using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.Configs.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LaserShotConfig", menuName = "Project/Weapon/LaserShotConfig", order = 1)]
    public class LaserShotConfig
    {
        public float BaseDamage;
    }
}
