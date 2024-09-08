using Assets.Project.Scripts.Models.Movement;
using Assets.Project.Scripts.Models.Rotation;
using UnityEngine;

namespace Assets.Project.Scripts.Models.Player
{
    public interface IPlayer : IControlable, IMovable, IRotatable
    {
        Rigidbody2D Rigidbody2D { get; }
    }
}
