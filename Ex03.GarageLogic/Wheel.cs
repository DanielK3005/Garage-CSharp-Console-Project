using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_ManufacturerName;
        private float m_AirPressure;
        private float m_MaxAirPressure;


        public Wheel(string i_ManufacturerName, float i_AirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_AirPressure = i_AirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void AddAirPressure(float i_AirAddOn)
        {
            if (i_AirAddOn + m_AirPressure < m_MaxAirPressure)
            {
                m_AirPressure += i_AirAddOn;
            }
            else
            {
                //TODO: Exception needed for add to much air pressure (over the max limit)
            }
        }
    }
}
