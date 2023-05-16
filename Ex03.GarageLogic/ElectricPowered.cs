using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricPowered : VehiclePowerSystem
    {
        private const string k_EnergyType = "Battery Hour";

        public ElectricPowered(float i_CurrentBatteryTime, float i_MaxBatteryTime)
        {
            m_CurrentEnergyAmount = i_CurrentBatteryTime;
            m_MaxEnergyAmount = i_MaxBatteryTime;
        }

        public void Recharge(float i_BatteryTimeAmount)
        {
            if (!AddEnergy(i_BatteryTimeAmount))
            {
                throw new EnergyCapacityException(k_EnergyType);
            }
        }
    }
}
