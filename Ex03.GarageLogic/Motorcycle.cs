using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer, List<Wheel> i_Wheel) : base(i_PowerSystem, i_VehicleType, i_Customer, i_Wheel)
        {
            m_Properties.Add("LicenseType", null);
            m_Properties.Add("EngineVolume", null);

            m_PropertiesValidator.Add("LicenseType", GetEnumValues(typeof(eMotorcycleLicenseType)).ToList());
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
