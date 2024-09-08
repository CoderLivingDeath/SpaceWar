using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Models.EventBus.EventHandlers
{
    public interface IPlayerMovementHandler : IGlobalSubscriber
    {
        void HandlePlayerMovement(Vector2 direction);
    }
}
