using Assets.Project.Scripts.Models.EventBus;
using Assets.Project.Scripts.Models.EventBus.EventHandlers;
using UnityEngine;

namespace Assets.Project.Scripts.Services
{
    public class InputService
    {
        private readonly InputActions _actions;
        private readonly IEventBus _eventBus;

        public InputService(InputActions actions, IEventBus eventBus)
        {
            _actions = actions;
            _eventBus = eventBus;

            _actions.Enable();

            Subsctibe();
        }

        public void Subsctibe()
        {
            _actions.Gameplay.Movement.performed += Movement_performed;
            _actions.Gameplay.Movement.canceled += Movement_canceled;

            _actions.Gameplay.Shoot.performed += Shoot_performed;
        }

        private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            bool dir = obj.ReadValueAsButton();
            _eventBus.RaiseEvent<IPlayerShootHandler>(h => h.HandlePlayerShoot());
        }

        private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector2 dir = obj.ReadValue<Vector2>();
            _eventBus.RaiseEvent<IPlayerMovementHandler>(h => h.HandlePlayerMovement(dir));
        }

        private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Vector2 dir = obj.ReadValue<Vector2>();
            _eventBus.RaiseEvent<IPlayerMovementHandler>(h => h.HandlePlayerMovement(dir));
        }
    }
}
