using Assets.Project.Scripts.Infrastructure.ControllersMapping;
using Assets.Project.Scripts.Infrastructure.ControllersMapping.Attributes;
using ModestTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Project.Scripts.Infrastructure.ControllersMapping
{
    public class ControllersMapper
    {
        private const string NAMESPACE_DEFAULT = "Controller";

        private Assembly _assembly;
        private readonly string Namespace;

        public ControllersMapper(Assembly? assembly = null, string? @namespace = null)
        {
            _assembly = assembly ?? Assembly.GetExecutingAssembly();
            this.Namespace = @namespace ?? NAMESPACE_DEFAULT;
        }

        public IEnumerable<ControllerMapItmeInfo> CreateMap()
        {
            var types = _assembly.GetTypes();
            var namespaceTypes = types.Where(t => t.FullName.StartsWith(Namespace));
            var MarkedControllers = namespaceTypes.Where(t => t.TryGetAttribute<ControllerAttribute>() != null);
            foreach (var type in MarkedControllers)
            {
                ControllerAttribute attribute = type.GetAttribute<ControllerAttribute>();
                yield return new ControllerMapItmeInfo(type, attribute.LifeScope, attribute.Lazy);
            }
        }
    }

}

public class ControllerMapItmeInfo
{
    public readonly Type ControllerType;
    public readonly LifeScopeEnum InitialType;
    public readonly bool Lazy;

    public ControllerMapItmeInfo(Type controllerType, LifeScopeEnum initialType, bool lazy)
    {
        ControllerType = controllerType;
        InitialType = initialType;
        Lazy = lazy;
    }
}
