using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Infrastructure.ControllersMapping.ZenjectMiddleware
{
    public static class MiddlewareZenjectControllerMappingExtention
    {
        private const string NAMESPACE_DEFAULT = "Assets.Project.Scripts.Controllers";

        public static void AddZenjectMiddlewareControllerMapping(this DiContainer container)
        {
            ControllersMapper mapper = new ControllersMapper(@namespace: NAMESPACE_DEFAULT);

            IEnumerable<ControllerMapItmeInfo> map = mapper.CreateMap();

            foreach (var info in map)
            {
                ConcreteIdBinderNonGeneric scope = container.Bind(info.ControllerType);
                switch (info.InitialType)
                {
                    case LifeScopeEnum.Singlton:
                        scope.AsSingle();
                        break;
                    case LifeScopeEnum.Transient:
                        scope.AsTransient();
                        break;
                    default:
                        throw new Exception();
                }

                if (info.Lazy) scope.Lazy();

                Debug.Log(info.ControllerType.Name);
            }
        }
    }
}
