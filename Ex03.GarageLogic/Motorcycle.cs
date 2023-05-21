using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eMotorcycleLicenseType m_LicenseType;

        //create only powersystem constructor
        public Motorcycle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Owner) : base(i_PowerSystem, i_VehicleType, i_Owner)
        {

        }

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
