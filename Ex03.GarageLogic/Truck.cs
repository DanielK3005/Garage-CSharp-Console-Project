using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.Car;

namespace Ex03.GarageLogic
{
    public class Truck: Vehicle
    {
        public Truck(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_customer, List<Wheel> i_Wheel) : base(i_PowerSystem, i_VehicleType, i_customer, i_Wheel)
        {
            m_Properties.Add("DangerousMaterials", null);
            m_Properties.Add("CargoVolume", null);

            m_PropertiesValidator.Add("DangerousMaterials", GetEnumValues(typeof(eDangerousMaterials)).ToList());
        }

        public enum eDangerousMaterials
        {
            Yes,
            No
        }

        
    }
}
