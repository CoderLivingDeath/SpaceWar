using System;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Infrastructure.Factory
{
    public class PlayerPrefabFactory : IFactory<GameObject>
    {
        private DiContainer _container;

        public PlayerPrefabFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create()
        {
            throw new NotImplementedException();
        }
    }
}
