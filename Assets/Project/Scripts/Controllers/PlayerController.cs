using Assets.Project.Scripts.Models.Movement;
using Assets.Project.Scripts.Models.Player;
using Assets.Project.Scripts.Models.Rotation;
using Assets.Project.Scripts.Services;
using UnityEngine;

namespace Assets.Project.Scripts.Controllers
{
    public class PlayerController
    {
        private PlayerControllService playerControllService;

        public PlayerController(PlayerControllService playerControllService)
        {
            this.playerControllService = playerControllService;
        }

        public void MovePlayer(IPlayer player ,Vector2 direction)
        {
            playerControllService.MovePlayer(player ,direction);
        }

        public void RotatePlayer(IPlayer player, Vector2 direction, float correctAngle)
        {
            playerControllService.RotatePlayer(player, direction, correctAngle);
        }
    }
}
