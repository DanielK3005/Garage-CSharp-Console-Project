using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer) : base(i_PowerSystem, i_VehicleType, i_Customer)
        {
            m_Properties.Add("LicenseType", null);
            m_Properties.Add("EngineVolume", null);

            m_PropertiesValidator.Add("LicenseType", GetEnumValues(typeof(eMotorcycleLicenseType)).ToList());
        }

        public override Dictionary<string, object> GetPropertiesDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("LicenseType", Enum.GetValues(typeof(eMotorcycleLicenseType)));
            keyValuePairs.Add("EngineVolume", null);

            return keyValuePairs;
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
