using Assets.Project.Scripts.Infrastructure.ChangesInfo;
using Assets.Project.Scripts.Services;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{

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
            Vector2 moveVector = _movementService.CalculateMoveVector(context.InputVector, context.OldMoveVector, context.LerpScale);
            Vector2 Offset = _movementService.CalculateOffset(moveVector, context.StepSize, _timeService.DeltaTime, _timeService.TimeScale);

            RigidBodyChangesInfo chenges = new(r => r.MovePosition(r.position + Offset));

            return new MovementResult(chenges, moveVector);
        }
    }
}
