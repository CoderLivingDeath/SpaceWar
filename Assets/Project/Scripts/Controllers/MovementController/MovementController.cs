using Assets.Project.Scripts.Infrastructure.Changes;
using Assets.Project.Scripts.Infrastructure.ControllersMapping;
using Assets.Project.Scripts.Infrastructure.ControllersMapping.Attributes;
using Assets.Project.Scripts.Services;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{
    [Controller(LifeScopeEnum.Singlton)]
    public class MovementController
    {
        private readonly IMovementService _movementService;
        private readonly ITimeService _timeService;

        public MovementController(IMovementService movementService, ITimeService timeService)
        {
            _movementService = movementService;
            _timeService = timeService;
        }

        public MovementResult Move(MovementContext context)
        {
            Vector2 Offset = _movementService.CalculateOffset(context.Direction, context.StepSize, _timeService.DeltaTime, _timeService.TimeScale);

            var result = new MovementResult(Offset, context);

            return result;
        }
    }
}
