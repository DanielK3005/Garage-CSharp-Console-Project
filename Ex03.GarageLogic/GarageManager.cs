using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<Customer, Vehicle> m_VehiclesList;

        public GarageManager()
        {
            m_VehiclesList = new Dictionary<Customer, Vehicle>();
        }

        public bool IsVehicleInTheGarage(string i_LicensedNumber)
        {
            bool foundVehicle = false;
            foreach (Vehicle var in m_VehiclesList.Values)
            {
                if (var.GetLicenseNumber().Equals(i_LicensedNumber))
                {
                    foundVehicle = true;
                    break;
                }
            }

            return foundVehicle;
        }

        public void ChangeVehicleGarageStatus(string i_LicensedNumber, Vehicle.eVehicleStatus i_SelectedVehicleStatus)
        {
            Vehicle vehicle = findVehicleInTheGarageByLicenseNumber(i_LicensedNumber);

            if (vehicle != null)
            {
                vehicle.SetVehicleStatus(i_SelectedVehicleStatus);
            }
        }

        private Vehicle findVehicleInTheGarageByLicenseNumber(string i_LicensedNumber)
        {
            Vehicle vehicle = null;
            foreach (Vehicle var in m_VehiclesList.Values)
            {
                if (var.GetLicenseNumber().Equals(i_LicensedNumber))
                {
                    vehicle = var;
                    break;
                }
            }

            return vehicle;
        }

        public void CreateNewVehicle()
        {

        }

        public List<string> GetLicensePlateNumbers(bool i_IsFiltered, Vehicle.eVehicleStatus i_FilteredStatus)
        {
            List<string> licensePlateNumbers = new List<string>();
            if (i_IsFiltered)
            {
                foreach(Vehicle var in m_VehiclesList.Values)
                {
                    if(var.GetVehicleStatus() == i_FilteredStatus)
                    {
                        licensePlateNumbers.Add(var.GetLicenseNumber());
                    }
                }
            }
            else
            {
                foreach (Vehicle var in m_VehiclesList.Values)
                {
                    licensePlateNumbers.Add(var.GetLicenseNumber());
                }
            }

            return licensePlateNumbers;
        }

        public void FlateTheWheelsToMax(string i_LicensedNumber)
        {
            Vehicle owner = findVehicleInTheGarageByLicenseNumber(i_LicensedNumber);

            if (owner != null)
            {
                foreach(Wheel var in owner.GetWheels())
                {
                    var.MakeAirPressureMax();
                }
            }
        }

        public void RefuelVehicle(string i_LicensedNumber, string i_FuelType, float i_FuelAmount)
        {
            Vehicle vehicle = findVehicleInTheGarageByLicenseNumber(i_LicensedNumber);
            InternalCombustionPowered.eFuelType fuelType = (InternalCombustionPowered.eFuelType) Enum.Parse(typeof(InternalCombustionPowered.eFuelType), i_FuelType);

            if (vehicle != null)
            {
                if(vehicle.IsFuelType())
                {
                    if(vehicle.GetVehiclePowerSystem() is InternalCombustionPowered f)
                    {
                        f.Refuel(i_FuelAmount, fuelType);
                    }
                }
            }
        }

        public void ChargeVehicle(string i_LicensedNumber, float i_ChargeAmount)
        {
            Vehicle vehicle = findVehicleInTheGarageByLicenseNumber(i_LicensedNumber);

            if (vehicle != null)
            {
                if (vehicle.IsElectricType())
                {
                    if (vehicle.GetVehiclePowerSystem() is ElectricPowered e)
                    {
                        e.Recharge(i_ChargeAmount);
                    }
                }
            }
        }
    }
}
