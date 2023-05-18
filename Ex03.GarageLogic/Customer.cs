using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Customer
    {
        private string m_Name;
        private string m_PhoneNumber;
        private Vehicle.eVehicleStatus m_VehicleStatus;

        public Customer(string i_Name, string i_PhoneNumber, Vehicle.eVehicleStatus i_VehicleStatus)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
            m_VehicleStatus = i_VehicleStatus;
        }

        public string GetName()
        {
            return m_Name;
        }

        public string GetPhoneNumber()
        {
            return m_PhoneNumber;
        }

        public Vehicle.eVehicleStatus GetVehicleStatus()
        {
            return m_VehicleStatus;
        }

        

    }
}
