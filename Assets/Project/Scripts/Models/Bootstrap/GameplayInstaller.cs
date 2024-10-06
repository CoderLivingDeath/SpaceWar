using Assets.Project.Scripts.Controllers;
using Assets.Project.Scripts.Controllers.MovementController;
using Assets.Project.Scripts.Infrastructure.Spawner;
using Assets.Project.Scripts.Models.EventBus;
using Assets.Project.Scripts.Services;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<BulletSpawner>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UnityTimeService>().AsSingle().NonLazy();
        Container.Bind<IEventBus>().To<EventBus>().AsSingle().NonLazy();
        Container.Bind<IMovementService>().To<MovementService>().AsSingle().NonLazy();
        Container.Bind<MovementController>().AsSingle().NonLazy();
        Container.Bind<InputActions>().AsSingle().NonLazy();
        Container.Bind<InputService>().AsSingle().NonLazy();
    }
}