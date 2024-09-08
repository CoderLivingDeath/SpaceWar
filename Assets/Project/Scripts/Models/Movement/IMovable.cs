using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project.Scripts.Models.Movement
{
    public interface IMovable
    {
        float StepSize {  get; }
    }
}
