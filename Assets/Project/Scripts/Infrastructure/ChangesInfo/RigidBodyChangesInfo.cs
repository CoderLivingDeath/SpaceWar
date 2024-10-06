using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.ChangesInfo
{
    public class RigidBodyChangesInfo : IRigidBodyChangesInfo
    {
        private readonly Action<Rigidbody2D> _changesApplyMethod;
        public void ApplyChanges(Rigidbody2D rigidbody)
        {
            _changesApplyMethod.Invoke(rigidbody);
        }

        public RigidBodyChangesInfo(Action<Rigidbody2D> changesApplyMethod)
        {
            _changesApplyMethod = changesApplyMethod;
        }
    }
}
