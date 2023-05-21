using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> m_VehiclesList;
        private VehicleFactory m_VehicleFactory;

        public GarageManager()
        {
            m_VehiclesList = new Dictionary<string, Vehicle>();
            m_VehicleFactory = new VehicleFactory();
        }

        public bool IsVehicleInTheGarage(string i_LicensedNumber)
        {
            return m_VehiclesList.ContainsKey(i_LicensedNumber);
        }

        public void ChangeVehicleGarageStatus(string i_LicensedNumber, Vehicle.eVehicleStatus i_SelectedVehicleStatus)
        {
            if (IsVehicleInTheGarage(i_LicensedNumber))
            {
                Vehicle vehicle = m_VehiclesList[i_LicensedNumber];
                vehicle.SetVehicleStatus(i_SelectedVehicleStatus);
            }
            else
            {
                //Throw a new NotInTheGargeException maybe?
            }
        }

        public Vehicle CreateNewVehicle(VehicleFactory.eVehicleType i_VehicleType , Customer i_Owner, string i_ManufacturerName)
        {
            m_VehicleFactory.TryCreateVehicle(i_VehicleType, out Vehicle vehicle , i_Owner, i_ManufacturerName);
            
            return vehicle;
        }

        public void ValidateAndConfirmVehicleData(Vehicle i_Vehicle, string i_ModelName, float i_EnergyUnits, float i_AirPressure, Dictionary<string, string> i_FurtherInfo)
        {
            i_Vehicle.ValidateAndAsignCommonData(i_ModelName, i_EnergyUnits, i_AirPressure);
            i_Vehicle.AssignAndValidateProperties(i_FurtherInfo);
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
            if (IsVehicleInTheGarage(i_LicensedNumber))
            {
                Vehicle owner = m_VehiclesList[i_LicensedNumber];

                foreach (Wheel var in owner.GetWheels())
                {
                    var.MakeAirPressureMax();
                }
            }
            else
            {
                //Throw a new NotInTheGargeException maybe?
            }

        }

        public void RefuelVehicle(string i_LicensedNumber, string i_FuelType, float i_FuelAmount)
        {
            if (IsVehicleInTheGarage(i_LicensedNumber))
            {
                Vehicle vehicle = m_VehiclesList[i_LicensedNumber];
                InternalCombustionPowered.eFuelType fuelType = (InternalCombustionPowered.eFuelType)Enum.Parse(typeof(InternalCombustionPowered.eFuelType), i_FuelType);

                if (vehicle.IsFuelType())
                {
                    if (vehicle.GetVehiclePowerSystem() is InternalCombustionPowered f)
                    {
                        f.Refuel(i_FuelAmount, fuelType);
                    }
                }
            }
            else
            {
                //Throw a new NotInTheGargeException maybe?
            }
        }

        public void ChargeVehicle(string i_LicensedNumber, float i_ChargeAmount)
        {
            if (IsVehicleInTheGarage(i_LicensedNumber))
            {
                Vehicle vehicle = m_VehiclesList[i_LicensedNumber];

                if (vehicle.IsElectricType())
                {
                    if (vehicle.GetVehiclePowerSystem() is ElectricPowered e)
                    {
                        e.Recharge(i_ChargeAmount);
                    }
                }
            }
            else
            {
                //Throw a new NotInTheGargeException maybe?
            }

        }
    }
}
