using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class GarageManager
    {
        private Dictionary<string, Vehicle> m_VehiclesList;

        public GarageManager()
        {
            m_VehiclesList= new Dictionary<string, Vehicle>();
        }

        public bool IsVehicleInTheGarage(string i_LicensedNumber)
        {
            return m_VehiclesList.ContainsKey(i_LicensedNumber);
        }

        public void ChangeVehicleGarageStatus(string i_LicensedNumber)
        {
            if(IsVehicleInTheGarage(i_LicensedNumber))
            {
                m_VehiclesList[i_LicensedNumber].SetVehicleStatus(Vehicle.eVehicleStatus.InRepair);
            }
        }


    }
}
