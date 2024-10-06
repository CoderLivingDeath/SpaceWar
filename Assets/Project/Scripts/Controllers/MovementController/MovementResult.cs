using Assets.Project.Scripts.Infrastructure.ChangesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers.MovementController
{
    public class MovementResult : IMovementResult
    {
        public readonly IRigidBodyChangesInfo Changes;
        public readonly Vector2 NewMoveVector;

        public MovementResult(IRigidBodyChangesInfo changes, Vector2 newMoveVector)
        {
            Changes = changes;
            NewMoveVector = newMoveVector;
        }
    }
}
