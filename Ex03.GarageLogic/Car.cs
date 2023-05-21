using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Costumer) : base(i_PowerSystem, i_VehicleType, i_Costumer)
        {

        }

        public override Dictionary<string, object> GetPropertiesDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("Color", Enum.GetValues(typeof(eCarColor)));
            keyValuePairs.Add("NumberOfDoors", Enum.GetValues(typeof(eNumberOfDoors)));

            return keyValuePairs;
        }

        public override void AssignAndValidateProperties(Dictionary<string, string> m_PropertiesDict)
        {
            foreach (KeyValuePair<string, string> property in m_PropertiesDict)
            {
                if (property.Key == "Color")
                {
                    if (Enum.TryParse(property.Value, out eCarColor color))
                    {
                        m_Color = color;
                    }
                    else
                    {
                        // Exception or something?
                    }
                }
                else if (property.Key == "NumberOfDoors")
                {
                    if (Enum.TryParse(property.Value, out eNumberOfDoors numberOfDoors))
                    {
                        m_NumberOfDoors = numberOfDoors;
                    }
                    else
                    {
                        // Exception or something?
                    }
                }
            }
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
