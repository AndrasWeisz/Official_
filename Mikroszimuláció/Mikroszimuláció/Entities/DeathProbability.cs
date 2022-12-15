using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroszimuláció.Entities
{
    internal class DeathProbability
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public double ProbOfDeath { get; set; }
    }
}
