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

        public Motorcycle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer, List<Wheel> i_Wheels) : base(i_PowerSystem, i_VehicleType, i_Customer, i_Wheels)
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
                        throw new ArgumentException("you didnt type correctly one of the options above");
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
                        throw new ArgumentException("you insert the wrong input type, this field gets integer only!");
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nLicense type: {m_LicenseType.ToString()}\nEngine volume: {m_EngineVolume}";
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
