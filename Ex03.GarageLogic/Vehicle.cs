using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private eVehicleType m_VehicleType;
        private float m_EnergyLeftPercentage;
        private VehiclePowerSystem m_PowerSystem;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        public enum eVehicleType
        {
            FuelMotorcycle,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public Vehicle(VehiclePowerSystem i_PowerSystem, eVehicleType i_VehicleType)
        {
            m_PowerSystem = i_PowerSystem;
            m_VehicleType = i_VehicleType;
        }

        public Vehicle(string i_LicenseNumber, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus, float i_EnergyLeftPercentage, VehiclePowerSystem i_PowerSystem)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
            m_EnergyLeftPercentage = i_EnergyLeftPercentage;
            m_PowerSystem = i_PowerSystem;
        }

        public virtual string DisplayInformation()
        {
            StringBuilder vehicleInformation = new StringBuilder();
            vehicleInformation.AppendFormat("License number: {0}", m_LicenseNumber);
            vehicleInformation.AppendFormat("Owner name: {0}", m_OwnerName);
            vehicleInformation.AppendFormat("Owner phone number: {0}", m_OwnerPhoneNumber);
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
            return ((m_VehicleType == eVehicleType.FuelMotorcycle) || (m_VehicleType == eVehicleType.Truck) || (m_VehicleType == eVehicleType.FuelCar));
        }

        public bool IsElectricType()
        {
            return ((m_VehicleType == eVehicleType.ElectricMotorcycle) || (m_VehicleType == eVehicleType.ElectricCar));
        }

        public VehiclePowerSystem GetVehiclePowerSystem()
        {
            return m_PowerSystem;
        }
    }
}
