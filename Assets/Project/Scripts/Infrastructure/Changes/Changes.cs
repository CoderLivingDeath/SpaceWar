using Assets.Project.Scripts.Controllers.MovementController;
using System;
using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.Changes
{
    public class Changes<T, TContext>
    {
        public TContext Context { get; }

        public Action<T> ApplyMethod => _changesApplyMethod;

        private readonly Action<T> _changesApplyMethod;

        public Changes(Action<T> changesApplyMethod, TContext context)
        {
            _changesApplyMethod = changesApplyMethod;
            Context = context;
        }

        public void Apply(T param)
        {
            _changesApplyMethod.Invoke(param);
        }

        public void Apply(Rigidbody2D param, MovementContext context)
        {
            throw new NotImplementedException();
        }
    }
}
