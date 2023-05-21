using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car: Vehicle
    {
        public Car(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Costumer, List<Wheel> i_Wheel) : base(i_PowerSystem, i_VehicleType, i_Costumer, i_Wheel)
        {
            m_Properties.Add("Color", null);
            m_Properties.Add("NumberOfDoors", null);

            m_PropertiesValidator.Add("Color", GetEnumValues(typeof(eCarColor)).ToList());
            m_PropertiesValidator.Add("NumberOfDoors", GetEnumValues(typeof(eNumberOfDoors)).ToList());
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
