using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricPowered : VehiclePowerSystem
    {
        public ElectricPowered(float i_CurrentBatteryTime, float i_MaxBatteryTime)
        {
            m_CurrentEnergyAmount = i_CurrentBatteryTime;
            m_MaxEnergyAmount = i_MaxBatteryTime;
        }

        public void Recharge(float i_BatteryTimeAmount)
        {
            if (!base.AddEnergy(i_BatteryTimeAmount))
            {
                throw new OverTheLimitException(m_CurrentEnergyAmount, m_MaxEnergyAmount, i_BatteryTimeAmount);
            }
        }
    }
}
