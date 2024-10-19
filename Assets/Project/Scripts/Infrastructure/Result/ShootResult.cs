namespace Assets.Project.Scripts.Controllers.ShootController
{
    public class ShootResult 
    {
        public ShootContext Context { get; }

        public ShootResult(ShootContext context)
        {
            Context = context;
        }
    }
}