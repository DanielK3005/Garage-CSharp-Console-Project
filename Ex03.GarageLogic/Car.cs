using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car:Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        public enum eCarColor
        {
            White,
            Black,
            Yellow,
            Red
        }
        public enum eNumberOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }

    }
}
