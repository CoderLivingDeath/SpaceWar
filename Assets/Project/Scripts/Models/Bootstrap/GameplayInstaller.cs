using Assets.Project.Scripts.Controllers;
using Assets.Project.Scripts.Models.EventBus;
using Assets.Project.Scripts.Models.Movement;
using Assets.Project.Scripts.Models.Rotation;
using Assets.Project.Scripts.Services;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<InputActions>().AsSingle().NonLazy();
        Container.Bind<EventBus>().AsSingle().NonLazy();
        Container.Bind<InputService>().AsSingle().NonLazy();
        Container.Bind<MovementHandler>().AsSingle().NonLazy();
        Container.Bind<RotationHandler>().AsSingle().NonLazy();
        Container.Bind<PlayerControllService>().AsSingle().NonLazy();
        Container.Bind<PlayerController>().AsSingle().NonLazy();
    }
}