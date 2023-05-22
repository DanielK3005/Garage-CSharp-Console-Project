﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Truck: Vehicle
    {
        private bool m_DangerousMaterials;
        private float m_CargoVolume;

        public Truck(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Customer, List<Wheel> i_Wheels) : base(i_PowerSystem, i_VehicleType, i_Customer, i_Wheels)
        {
        }

        public override Dictionary<string, object> GetPropertiesDictionary()
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            keyValuePairs.Add("DangerousMaterials", Enum.GetValues(typeof(eDangerousMaterials)));
            keyValuePairs.Add("CargoVolume", null);

            return keyValuePairs;
        }

        public override void AssignAndValidateProperties(Dictionary<string, string> m_PropertiesDict)
        {
            foreach (KeyValuePair<string, string> property in m_PropertiesDict)
            {
                if (property.Key == "DangerousMaterials")
                {
                    if (Enum.TryParse(property.Value, out eDangerousMaterials dangerMatrial))
                    {
                        if (dangerMatrial == eDangerousMaterials.True)
                        {
                            m_DangerousMaterials = true;
                        }
                        else if (dangerMatrial == eDangerousMaterials.False)
                        {
                            m_DangerousMaterials = false;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("you didnt type correctly one of the options above");
                    }
                }
                else if (property.Key == "CargoVolume")
                {
                    if (float.TryParse(property.Value, out float CargoVolume))
                    {
                        m_CargoVolume = CargoVolume;
                    }
                    else
                    {
                        throw new ArgumentException("you insert the wrong input type, this field gets float only!");
                    }
                }
            }
        }

        public enum eDangerousMaterials
        {
            True = 0,
            False = 1
        }
    }
}
