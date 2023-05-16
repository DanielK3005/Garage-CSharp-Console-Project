using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class NoMatchingFuelException : Exception
    {
      public NoMatchingFuelException() : base("No matching fuel type")
      {

      }
    }
}
