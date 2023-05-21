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
        private eMotorcycleLicenseType m_LicenseType;
        private int m_EngineVolume;

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

        public override void AssignAndValidateProperties(Dictionary<string, string> m_PropertiesDict)
        {
            foreach (KeyValuePair<string, string> property in m_PropertiesDict)
            {
                if (property.Key == "LicenseType")
                {
                    if (Enum.TryParse(property.Value, out eMotorcycleLicenseType type))
                    {
                        m_LicenseType = type;
                    }
                    else
                    {
                        // Exception or something?
                    }
                }
                else if (property.Key == "EngineVolume")
                {
                    if (int.TryParse(property.Value, out int EngineVolume))
                    {
                        m_EngineVolume = EngineVolume;
                    }
                    else
                    {
                        // Exception or something?
                    }
                }
            }
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
