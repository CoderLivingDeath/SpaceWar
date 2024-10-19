using Assets.Project.Scripts.Infrastructure.ControllersMapping;
using System;

namespace Assets.Project.Scripts.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ShootControllerAttribute : Attribute
    {
        public Type Target { get; set; }
        public ShootControllerAttribute(Type target, LifeScopeEnum lifeScope = LifeScopeEnum.Singlton, bool lazy = true)
        {
            Target = target;
        }
    }
}
