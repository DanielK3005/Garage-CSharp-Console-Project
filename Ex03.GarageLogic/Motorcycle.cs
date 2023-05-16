using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus, float i_EnergyLeftPercentage, VehiclePowerSystem i_PowerSystem, eMotorcycleLicenseType i_LicenseType) 
        : base(i_LicenseNumber, i_Wheels, i_OwnerName, i_OwnerPhoneNumber, i_VehicleStatus, i_EnergyLeftPercentage, i_PowerSystem)
        {
           m_LicenseType = i_LicenseType;
        }

        public eMotorcycleLicenseType GetLicenseType()
        {
            return m_LicenseType;
        }


        
        public enum eMotorcycleLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
    }
}
