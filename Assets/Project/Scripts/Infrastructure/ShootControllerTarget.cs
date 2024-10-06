using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ShootControllerTargetAttribute : Attribute
    {
        public Type Target { get; set; }
        public ShootControllerTargetAttribute(Type target)
        {
            Target = target;
        }
    }
}
