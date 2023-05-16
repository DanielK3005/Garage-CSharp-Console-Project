﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class VehiclePowerSystem
    {
        protected float m_MaxEnergyAmount;
        protected float m_CurrentEnergyAmount;

        public void AddEnergy(float i_EnergyAmountToAdd)
        {
            if ((m_MaxEnergyAmount - m_CurrentEnergyAmount) >= i_EnergyAmountToAdd)
            {
                m_CurrentEnergyAmount += i_EnergyAmountToAdd;
            }
            else
            {
                throw new OverTheLimitException(m_CurrentEnergyAmount, m_MaxEnergyAmount, i_EnergyAmountToAdd);
            }
        }
    }
}
