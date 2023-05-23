using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_VehicleModelName;
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private VehicleFactory.eVehicleType m_VehicleType;
        private float m_EnergyLeftPercentage;
        private VehiclePowerSystem m_PowerSystem;
        private Customer m_Customer;
        public Dictionary<string, object> m_Properties;
        public Dictionary<string, object> m_PropertiesValidator;
        public eVehicleStatus m_VehicleStatus;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid,
            None
        }

        public Vehicle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Custumer, List<Wheel> i_Wheels)
        {
            m_PowerSystem = i_PowerSystem;
            m_VehicleType = i_VehicleType;
            m_LicenseNumber = null;
            m_Customer = i_Custumer;
            m_Wheels = i_Wheels;
            m_Properties = new Dictionary<string, object>();
            m_PropertiesValidator = new Dictionary<string, object>();
        }

        public virtual Dictionary<string, object> GetPropertiesDictionary() 
        {
            return new Dictionary<string, object>();
        }

        public virtual void AssignAndValidateProperties(Dictionary<string, string> m_PropertiesDict)
        {

        }

        public Dictionary<string, object> GetProperties()
        {
            return m_Properties;
        }

        public override string ToString()
        {
            return $"License number: {m_LicenseNumber}\nModel name: {m_VehicleModelName}\nOwner name: {m_Customer.GetName()}" +
                $"\nVehicle status: {m_VehicleStatus.ToString()}\nVehicle type: {m_VehicleType.ToString()}\nFuel\\Battery situation: {m_PowerSystem.ToString()}" +
                $"\nWheel situation: {makeWheelsDataString()}";
        }

        private string makeWheelsDataString()
        {
            string output = "";
            foreach (var wheel in m_Wheels)
            {
                output += $" {wheel.ToString()}";
            }
            return output;
        }

        public eVehicleStatus GetVehicleStatus()
        {
            return m_VehicleStatus;
        }

        public void ValidateAndAsignCommonData(string i_ModelName, float i_EnergyUnits, float i_AirPressure, string i_LisenceNumber)
        {
            
            m_VehicleModelName = i_ModelName;
            m_VehicleStatus = eVehicleStatus.InRepair;
            m_LicenseNumber = i_LisenceNumber;
            

            if(m_PowerSystem is ElectricPowered electric)
            {
                electric.Recharge(i_EnergyUnits);
            }
            else if(m_PowerSystem is InternalCombustionPowered fuel)
            {
                fuel.AddEnergy(i_EnergyUnits);
            }

            foreach(Wheel wheel in m_Wheels)
            {
                wheel.AddAirPressure(i_AirPressure);
            }

        }

        public void SetVehicleStatus(eVehicleStatus i_VehicleStatus)
        {
            m_VehicleStatus = i_VehicleStatus;
        }

        public string GetLicenseNumber()
        {
            return m_LicenseNumber;
        }

        public List<Wheel> GetWheels()
        {
            return m_Wheels;
        }

        public bool IsFuelType()
        {
            return ((m_VehicleType == VehicleFactory.eVehicleType.FuelMotorcycle) || (m_VehicleType == VehicleFactory.eVehicleType.Truck) || (m_VehicleType == VehicleFactory.eVehicleType.FuelCar));
        }

        public bool IsElectricType()
        {
            return ((m_VehicleType == VehicleFactory.eVehicleType.ElectricMotorcycle) || (m_VehicleType == VehicleFactory.eVehicleType.ElectricCar));
        }

        public VehiclePowerSystem GetVehiclePowerSystem()
        {
            return m_PowerSystem;
        }

        public void setVehicleModelName(string i_ModelName)
        {
            m_VehicleModelName = i_ModelName;
        }

        protected IEnumerable<object> GetEnumValues(Type enumType)
        {
            return Enum.GetValues(enumType).Cast<object>();
        }
    }
}
