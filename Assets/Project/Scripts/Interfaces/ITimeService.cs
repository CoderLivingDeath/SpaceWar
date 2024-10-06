namespace Assets.Project.Scripts.Services
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        float TimeScale { get; }
    }
}