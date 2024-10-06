using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts.Infrastructure.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }

    public interface IFactory<out T, in Arg>
    {
        T Create(Arg arg);
    }
}
