using Assets.Project.Scripts.Services.WeaponServices;
using System;
using Zenject;

namespace Assets.Project.Scripts.Infrastructure.Factory
{
    public class BulletFactory : IFactory<BulletShot>
    {
        private DiContainer _diCotainer;

        public BulletFactory(DiContainer diCotainer)
        {
            _diCotainer = diCotainer;
        }

        public BulletShot Create()
        {
            throw new NotImplementedException();
        }
    }
}
