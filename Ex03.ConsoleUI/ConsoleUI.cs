﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        
        public void DisplayAllAvailableVehicleStatus()
        {
            Console.WriteLine("Please choose one of the following options:");
            
        }

        public void pressAnyKeyToReturnToTheMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        public void DisplayInflatedWheelsToMax()
        {
            //Console.Clear();
            Console.WriteLine("All the wheels of the vehicle had been inflated to max pressure");
        }

        public string GetLicensePlate()
        {

            //Console.Clear();
            string licenseNumber;

            Console.WriteLine("Please enter the vehicle's license number:");
            licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public void PrintListOfLicenseNumber(List<string> i_LicenseNumbers, Vehicle.eVehicleStatus i_VehicleStatus)
        {
            //Console.Clear();
            Console.WriteLine("Filtered license numbers by: {0}", i_VehicleStatus.ToString());

            if (i_LicenseNumbers.Count() != 0)
            {
                foreach (string licenseNumber in i_LicenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
            else
            {
                Console.WriteLine("No vehicles found!");
            }

        }

        public void DisplayVehicleAlreadyInTheGarage()
        {
            //Console.Clear();
            Console.WriteLine("Vehicle is already in the garage. \nVehicle status has been updated to \"In repair\" ");
        }

        public void DisplayVehicleInformation(string i_VehicleInformation)
        {
            Console.Write(i_VehicleInformation);
        }


        public void DisplayVehicleDoesNotExists()
        {
            Console.WriteLine("The vehicle does not exist in the garage.");
            Console.WriteLine("Let's proceed to add a new vehicle.");
        }


        public Customer GetCustomerDetails()
        {
            string nameInput, phoneInput;

            Console.WriteLine("what is your name?");
            nameInput = Console.ReadLine();
            Console.WriteLine("what is your phone number?");
            phoneInput = Console.ReadLine();

            return new Customer(nameInput, phoneInput);
        }

        public void GetVehicleTypeFromUser(out VehicleFactory.eVehicleType vehicleType)
        {
            do
            {
                Console.WriteLine("Enter the vehicle type:");
                PrintListOfVehicleTypes();

                int userInput;
                bool isValidInput = int.TryParse(Console.ReadLine(), out userInput);

                userInput -= 1;

                if (isValidInput && Enum.IsDefined(typeof(VehicleFactory.eVehicleType), userInput))
                {
                    vehicleType = (VehicleFactory.eVehicleType)userInput;
                    break;
                }

                Console.WriteLine("Invalid input. Please try again.");
            } while (true);
        }


        public void PrintListOfVehicleTypes()
        {
            int listItemCounter = 1;

            foreach (VehicleFactory.eVehicleType type in Enum.GetValues(typeof(VehicleFactory.eVehicleType)))
            {
                Console.WriteLine("{0}. {1}", listItemCounter, type.ToString());
                listItemCounter++;
            }
        }

        public void GetVehicleInfoFromUser(Vehicle i_Vehicle, VehicleFactory.eVehicleType i_VehicleType, out string o_ModelName, out float o_EnergyUnits, out float o_AirPressure, out Dictionary<string, string> o_VehicleExtraInfo)
        {
            VehiclePowerSystem vehiclePowerSystem = i_Vehicle.GetVehiclePowerSystem();
            CollectCommonVehicleInfoFromUser(i_Vehicle, out o_ModelName, out o_EnergyUnits, out o_AirPressure);

            o_VehicleExtraInfo = GetFurtherVehicleInfo(i_Vehicle);

        }

        public string GetManufacturerWheelName()
        {
            Console.WriteLine("what is the name of your vehicle wheels manufacturer?");
            return Console.ReadLine();
        }

        public void DisplayNewVehicleAddedWithInRepairStatus(Vehicle i_Vehicle)
        {
            //Console.Clear();
            Console.WriteLine("New vehicle added to the garage.");
            Console.WriteLine("Vehicle status has been set to \"InRepair\".");

        }

        public Dictionary<string, string> GetFurtherVehicleInfo(Vehicle i_Vehicle)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            Dictionary<string, object> propertiesDictionary = i_Vehicle.GetPropertiesDictionary();

            foreach (KeyValuePair<string, object> property in propertiesDictionary)
            {
                Console.WriteLine($"Enter the value for {property.Key}:");
                if(property.Value != null)
                {
                    Console.WriteLine($"Available options for {property.Key}:");
                    foreach (var option in (Array)property.Value)
                    {
                        Console.WriteLine(option);
                    }
                }

                string propertyValue = Console.ReadLine();

                properties[property.Key] = propertyValue;
            }

            return properties;
        }

        public void CollectCommonVehicleInfoFromUser(Vehicle i_Vehicle, out string i_ModelName, out float i_EnergyUnits, out float i_AirPressure)
        {
            i_ModelName = GetFromTheUserTheVehicleModelName();
            i_EnergyUnits = GetFromUserTheAmountEnergyUnitsAvailable(i_Vehicle);
            i_AirPressure = GetAirPressureWheelsFromUser();
        }

        public float GetAirPressureWheelsFromUser()
        {
            string input;
            float wheelsAirPressure;

            Console.WriteLine("what is your wheels air pressure? (insert one number which indicates your vehicle wheels air pressure)");
            input = Console.ReadLine();

            if(!float.TryParse(input, out wheelsAirPressure))
            {
                throw new FormatException();
            }
            return wheelsAirPressure;
        }

        public void DisplayVehicleStatusUpdated()
        {
            Console.WriteLine();
            Console.WriteLine("Vehicle status has been updated.");
        }

        public Vehicle.eVehicleStatus GetVehicleStatusFromUser()
        {
            Console.WriteLine("Enter the status:");
            Array statusValues = Enum.GetValues(typeof(Vehicle.eVehicleStatus));

            for (int i = 0; i < statusValues.Length; i++)
            {
                Console.WriteLine($"{i+1}. {statusValues.GetValue(i)}");
            }

            int userInput;
            bool isValidInput = false;
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out userInput);
                userInput -= 1;

                if (isValidInput && Enum.IsDefined(typeof(Vehicle.eVehicleStatus), userInput))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Choose one of the above");
            } while (!isValidInput);

            return (Vehicle.eVehicleStatus)userInput;
        }

        public float GetFromUserTheAmountEnergyUnitsAvailable(Vehicle i_vehicle)
        {
            VehiclePowerSystem vehiclePowerSystem = i_vehicle.GetVehiclePowerSystem();
            float EnergySourceUnitsAvailable;
            string input;

            if (vehiclePowerSystem is ElectricPowered)
            {
                Console.WriteLine("What amount of battery hours the vehicle has?");
            }
            else if (vehiclePowerSystem is InternalCombustionPowered)
            {
                Console.WriteLine("What amount of fuel the vehicle has?");
            }

            input = Console.ReadLine();
            
            if(!float.TryParse(input, out EnergySourceUnitsAvailable))
            {
                throw new FormatException();
            }

            return EnergySourceUnitsAvailable;
        }

        public InternalCombustionPowered.eFuelType GetFromUserFuelTypeForRefuel()
        {
            Console.WriteLine("Enter the fuel type for the refuel:");
            Array statusValues = Enum.GetValues(typeof(InternalCombustionPowered.eFuelType));

            for (int i = 0; i < statusValues.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {statusValues.GetValue(i)}");
            }

            int userInput;
            bool isValidInput = false;
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out userInput);
                userInput -= 1;

                if (isValidInput && Enum.IsDefined(typeof(InternalCombustionPowered.eFuelType), userInput))
                {
                    break;
                }

                Console.WriteLine("Invalid input. Choose one of the above");
            } while (!isValidInput);

            return (InternalCombustionPowered.eFuelType)userInput;
        }

        public float GetAmountOfFuelToRefuelFromUser()
        {
            bool validInput = false;
            float fuelAmount;

            Console.WriteLine("Enter the amount of fuel that you want for the refuel:");
            validInput = float.TryParse(Console.ReadLine(), out fuelAmount);

            if (!validInput)
            {
                throw new FormatException();
            }

            return fuelAmount;
        }

        public float GetAmountOfBatteryPercentageToChargeFromUser()
        {
            bool validInput = false;
            float batteryAmount;

            Console.WriteLine("Enter the amount of battery percentage that you want to add for charging your vehicle:");
            validInput = float.TryParse(Console.ReadLine(), out batteryAmount);

            if (!validInput)
            {
                throw new FormatException();
            }

            return batteryAmount;
        }

        public string GetFromTheUserTheVehicleModelName()
        {
            string modelName;

            Console.WriteLine("Provide the model name of the vehicle: ");
            modelName = Console.ReadLine();

            return modelName;
        }

        
    }
}
