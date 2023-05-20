using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car: Vehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(VehiclePowerSystem i_PowerSystem, eVehicleType i_VehicleType) : base(i_PowerSystem, i_VehicleType)
        {
        }

        public Car(string i_LicenseNumber, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus, float i_EnergyLeftPercentage, VehiclePowerSystem i_PowerSystem, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        : base(i_LicenseNumber, i_Wheels, i_OwnerName, i_OwnerPhoneNumber, i_VehicleStatus, i_EnergyLeftPercentage, i_PowerSystem)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }
        
        public enum eCarColor
        {
            White = 0,
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
