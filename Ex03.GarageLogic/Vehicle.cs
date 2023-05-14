using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private eVehicleType m_VehicleType;

        public Vehicle(string modelName, string licenseNumber, float energyPercentage, List<Wheel> wheels, string ownerName, string ownerPhoneNumber, eVehicleStatus vehicleStatus, eVehicleType vehicleType)
        {
            m_ModelName = modelName;
            m_LicenseNumber = licenseNumber;
            m_EnergyPercentage = energyPercentage;
            m_Wheels = wheels;
            m_OwnerName = ownerName;
            m_OwnerPhoneNumber = ownerPhoneNumber;
            m_VehicleStatus = vehicleStatus;
            m_VehicleType = vehicleType;
        }

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
        }

        //enum vehicle type regular or electric
        public enum eVehicleType
        {
            Regular,
            Electric
        }

        public virtual string DisplayInformation()
        {
            StringBuilder vehicleInformation = new StringBuilder();
            vehicleInformation.AppendFormat("Model name: {0}", m_ModelName);
            vehicleInformation.AppendFormat("License number: {0}", m_LicenseNumber);
            vehicleInformation.AppendFormat("Energy percentage: {0}", m_EnergyPercentage);
            vehicleInformation.AppendFormat("Owner name: {0}", m_OwnerName);
            vehicleInformation.AppendFormat("Owner phone number: {0}", m_OwnerPhoneNumber);
            vehicleInformation.AppendFormat("Vehicle status: {0}", m_VehicleStatus);
            vehicleInformation.AppendFormat("Vehicle type: {0}", m_VehicleType);
            return vehicleInformation.ToString();
        }
    }
}
