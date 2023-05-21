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
            Paid
        }

        public Vehicle(VehiclePowerSystem i_PowerSystem, VehicleFactory.eVehicleType i_VehicleType, Customer i_Custumer)
        {
            m_PowerSystem = i_PowerSystem;
            m_VehicleType = i_VehicleType;
            m_LicenseNumber = null;
            m_Customer = i_Custumer;

            m_Properties = new Dictionary<string, object>();
            m_PropertiesValidator = new Dictionary<string, object>();
        }

        public virtual Dictionary<string, object> GetPropertiesDictionary() 
        {
            return new Dictionary<string, object>();
        }

        public Dictionary<string, object> GetProperties()
        {
            return m_Properties;
        }

        public virtual string DisplayInformation()
        {
            StringBuilder vehicleInformation = new StringBuilder();
            vehicleInformation.AppendFormat("License number: {0}", m_LicenseNumber);
            vehicleInformation.AppendFormat("Vehicle status: {0}", m_VehicleStatus);
            return vehicleInformation.ToString();
        }

        public eVehicleStatus GetVehicleStatus()
        {
            return m_VehicleStatus;
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
