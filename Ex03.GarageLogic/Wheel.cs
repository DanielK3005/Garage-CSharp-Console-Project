﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;


        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            if (i_CurrentAirPressure <= i_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }
            else
            {
                throw new ArgumentOutOfRangeException("current air pressure", String.Format("the air pressure must be between 0 to max pressure which is {0}.", i_MaxAirPressure));
            }
        }

        public void AddAirPressure(float i_AmountOfAirToAdd)
        {
            if (i_AmountOfAirToAdd + this.m_CurrentAirPressure <= m_MaxAirPressure)
            {
                this.m_CurrentAirPressure += i_AmountOfAirToAdd;
            }
            else
            {
                throw new OverTheLimitException(this.m_CurrentAirPressure, this.m_MaxAirPressure, i_AmountOfAirToAdd);
            }
        }
    }
}
