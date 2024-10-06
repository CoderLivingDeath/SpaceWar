using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Project.Scripts.Services
{
    public class UnityTimeService : ITickable, ITimeService
    {
        private const float TIMESCALE_DEFAULT = 1.0f;

        public float DeltaTime { get; private set; }
        public float TimeScale { get; private set; }

        public UnityTimeService()
        {
            TimeScale = TIMESCALE_DEFAULT;
        }

        public void Tick()
        {
            DeltaTime = Time.deltaTime;
        }
    }
}
