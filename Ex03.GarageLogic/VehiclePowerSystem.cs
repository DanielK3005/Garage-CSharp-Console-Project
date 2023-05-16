using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class VehiclePowerSystem
    {
        protected float m_MaxEnergyAmount;
        protected float m_CurrentEnergyAmount;

        public bool AddEnergy(float i_EnergyAmountToAdd)
        {
            bool result = false;

            if ((m_MaxEnergyAmount - m_CurrentEnergyAmount) >= i_EnergyAmountToAdd)
            {
                m_CurrentEnergyAmount += i_EnergyAmountToAdd;
                result = true;
            }

            return result;
        }
    }
}
