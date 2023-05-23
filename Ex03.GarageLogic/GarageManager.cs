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

        public string GetAllVehiclesInformation()
        {
            StringBuilder allVehiclesInformation = new StringBuilder();

            foreach (Vehicle vehicle in m_VehiclesList.Values)
            {
                allVehiclesInformation.AppendLine(vehicle.DisplayInformation());
                allVehiclesInformation.AppendLine("--------------------------------------");
            }

            return allVehiclesInformation.ToString();
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
                throw new NotInTheGarageException(i_LicensedNumber);
            }
        }

        public Vehicle CreateNewVehicle(VehicleFactory.eVehicleType i_VehicleType , Customer i_Owner, string i_ManufacturerName)
        {
            m_VehicleFactory.TryCreateVehicle(i_VehicleType, out Vehicle vehicle , i_Owner, i_ManufacturerName);
            
            return vehicle;
        }

        public void ValidateAndConfirmVehicleData(Vehicle i_Vehicle, string i_ModelName, float i_EnergyUnits, float i_AirPressure, Dictionary<string, string> i_FurtherInfo, string i_LisenceNumber)
        {
            i_Vehicle.ValidateAndAsignCommonData(i_ModelName, i_EnergyUnits, i_AirPressure, i_LisenceNumber);
            i_Vehicle.AssignAndValidateProperties(i_FurtherInfo);
        }

        public List<string> GetLicensePlateNumbers(Vehicle.eVehicleStatus i_FilteredStatus)
        {
            List<string> licensePlateNumbers = new List<string>();

            if (i_FilteredStatus != Vehicle.eVehicleStatus.None)
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

        public void InflateTheWheelsToMax(string i_LicensedNumber)
        {
            if (IsVehicleInTheGarage(i_LicensedNumber))
            {
                Vehicle vehicle = m_VehiclesList[i_LicensedNumber];

                foreach (Wheel var in vehicle.GetWheels())
                {
                    var.MakeAirPressureMax();
                }
            }
            else
            {
                throw new NotInTheGarageException(i_LicensedNumber);
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
                throw new NotInTheGarageException(i_LicensedNumber);
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
                throw new NotInTheGarageException(i_LicensedNumber);
            }

        }

        public void AddVehicleToGarage(string i_LisenceNumber, Vehicle i_Vehicle)
        {
            m_VehiclesList.Add(i_LisenceNumber, i_Vehicle);
        }
        
    }
}
