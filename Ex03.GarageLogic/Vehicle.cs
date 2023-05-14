using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        private string m_LicenseNumber;
        private List<Wheel> m_Wheels;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;

        public Vehicle(string i_LicenseNumber, List<Wheel> i_Wheels, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleStatus i_VehicleStatus)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
        }

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid
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
    }
}
