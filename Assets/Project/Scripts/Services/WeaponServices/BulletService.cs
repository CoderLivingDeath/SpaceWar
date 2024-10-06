using Assets.Project.Scripts.Infrastructure.Spawner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts.Services.WeaponServices
{
    public class BulletService
    {
        private BulletSpawner _spawner;

        public BulletService(BulletSpawner spawner)
        {
            _spawner = spawner;
        }

        public void SpawnBullet(BulletSpawnParameters parameters)
        {
            _spawner.Spawn(parameters);
        }
    }
}
