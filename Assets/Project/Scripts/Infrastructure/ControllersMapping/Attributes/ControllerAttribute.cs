using System;

namespace Assets.Project.Scripts.Infrastructure.ControllersMapping.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ControllerAttribute : Attribute
    {
        public readonly LifeScopeEnum LifeScope;
        public readonly bool Lazy;

        public ControllerAttribute(LifeScopeEnum lifeScope = LifeScopeEnum.Singlton, bool lazy = true)
        {
            LifeScope = lifeScope;
            Lazy = lazy;
        }
    }
}
