using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Models.EventBus.EventHandlers
{
    public interface IPlayerRotationHandler : IGlobalSubscriber
    {
        void HandlePlayerRotate(Vector2 direction);
    }
}
