using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.ChangesInfo
{
    public interface IRigidBodyChangesInfo
    {
        void ApplyChanges(Rigidbody2D rigidbody);
    }
}