using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class EnergyCapacityException : Exception
    {
        public EnergyCapacityException(string energyType) : base($"Amount of {energyType} added is bigger than the available capacity.")
        {

        }
    }
}
