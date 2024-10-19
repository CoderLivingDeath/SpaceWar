using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{
    public class MovementResult
    {
        public readonly Vector2 NewOffset;

        public readonly MovementContext Context;

        public MovementResult(Vector2 newOffset, MovementContext context )
        {
            NewOffset = newOffset;
            Context = context;
        }
    }
}
