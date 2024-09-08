using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Project.Scripts.Models.EventBus.EventHandlers.HandlersGroup
{
    public interface IPlayerInputHandlers: IPlayerMovementHandler, IPlayerRotationHandler, IPlayerShootHandler
    {
    }
}
