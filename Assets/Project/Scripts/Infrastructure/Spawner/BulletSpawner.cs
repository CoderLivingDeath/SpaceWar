using Assets.Project.Scripts.Controllers.ShootController;
using Assets.Project.Scripts.Services.WeaponServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Infrastructure.Spawner
{
    public class BulletSpawner
    {
        private DiContainer _container;

        public BulletSpawner(DiContainer container)
        {
            _container = container;
        }

        public void Spawn(BulletShotConfig config, Vector3 position, Quaternion rotation)
        {
            GameObjectCreationParameters parameters = new GameObjectCreationParameters();
            parameters.Position = position;
            parameters.Rotation = rotation;

            GameObject bullet = _container.InstantiatePrefab(config.Prefab, parameters);
            bullet.GetComponent<Rigidbody>().AddForce(rotation.eulerAngles.normalized * config.InitialSpeed, ForceMode.Force);
        }
        public void Spawn(BulletSpawnParameters parameters)
        {
            GameObjectCreationParameters GameObjectCreationParameters = new GameObjectCreationParameters();
            GameObjectCreationParameters.Position = parameters.position;
            GameObjectCreationParameters.Rotation = parameters.rotation;

            GameObject bullet = _container.InstantiatePrefab(parameters.config.Prefab, GameObjectCreationParameters);
            bullet.GetComponent<Rigidbody>().AddForce(parameters.rotation.eulerAngles.normalized * parameters.config.InitialSpeed, ForceMode.Force);
        }
    }
}
