using Assets.Project.Scripts.Controllers.ShootController;

namespace Assets.Project.Scripts.Models.Weapon
{
    public class PhysicalWeapon : WeaponBase
    {
        public BulletShotConfig[] RegistredBullets { get; private protected set; }
        public int CurrentBulletId { get; private protected set; }
        public int MaxBulletsInMagazine { get; private protected set; }
        public int CurrentBuletsInMagazine { get; private protected set; }

        public PhysicalWeapon(BulletShotConfig[] registredBullet, int currentBulletId = 0)
        {
            if (registredBullet.Length > 0) throw new System.Exception("Массив зарегестрированных боеприпасов для оружия не должен быть пустым.");
            if (currentBulletId < -1 && currentBulletId > registredBullet.Length) throw new System.Exception("Id текущего боеприпаса не должно выходит за диапозон массива");

            RegistredBullets = registredBullet;
            CurrentBulletId = currentBulletId;
        }

        public PhysicalWeapon(PhysicalWeaponConfig config, int currentBulletId = 0)
        {
            if (currentBulletId < -1 && currentBulletId > config.RegistredBullet.Length) throw new System.Exception("Id текущего боеприпаса не должно выходит за диапозон массива");
            if(MaxBulletsInMagazine < 0) throw new System.Exception("Размер магазина не может быть отрицательным");

            RegistredBullets = config.RegistredBullet;
            MaxBulletsInMagazine = config.MaxBulletsInMagazine;
            CurrentBulletId = currentBulletId;
        }

        public void SetCurrentBullet(int id)
        {
            if (id == CurrentBulletId) return;

            if (id > -1 && id < RegistredBullets.Length)
            {
                CurrentBulletId = id;
            }
        }
    }
}
