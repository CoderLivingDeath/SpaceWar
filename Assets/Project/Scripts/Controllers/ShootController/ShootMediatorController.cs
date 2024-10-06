using Assets.Project.Scripts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Project.Scripts.Controllers.ShootController
{
    public class ShootMediatorController
    {
        private Dictionary<Type, Type> _shootControllersMap;
        private Dictionary<Type, ShootController> _shootControllers;
        public ShootMediatorController(IEnumerable<ShootController> shootControllers)
        {
            var pairs = GetShootControllerTypes();
            foreach (var pair in pairs)
            {
                _shootControllersMap.Add(pair.Item1, pair.Item2);
            }

            _shootControllers = new Dictionary<Type, ShootController>();
            foreach (var controller in shootControllers)
            {
                var targetAttribute = controller.GetType().GetCustomAttribute<ShootControllerTargetAttribute>();
                var target = targetAttribute.Target;

                _shootControllers.Add(target, controller);
            }
        }

        public ShootResult Shoot(ShootContext context)
        {
            if (_shootControllers.TryGetValue(context.Weapon.GetType(), out var controller))
            {
                return controller.Shoot(context);
            }
            else
            {
                throw new Exception();
            }
        }

        private IEnumerable<(Type, Type)> GetShootControllerTypes()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            var controllers = types.Where(t => t.GetCustomAttributes(typeof(ShootControllerTargetAttribute), false).Any());
            foreach (var controllerType in controllers)
            {
                var attribute = controllerType.GetCustomAttribute<ShootControllerTargetAttribute>();
                yield return (attribute.Target, controllerType);
            }
        }
    }
}
