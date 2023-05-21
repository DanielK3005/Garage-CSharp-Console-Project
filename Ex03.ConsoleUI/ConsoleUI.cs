using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        
        public string GetLicensePlate()
        {
            string licenseNumber;

            Console.WriteLine("Please enter the vehicle's license number:");
            licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public void DisplayVehicleAlreadyInTheGarage()
        {
            Console.WriteLine("Vehicle already in the garage");
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

        public string DisplayAskForFuelDetailsOfVehicle()
        {
            return "";
        }

        public string DisplayAskForElectricDetailsOfVehicle()
        {
            return "";
        }

        public string DisplayAskForCarDetails()
        {
            return "";
        }

        public string DisplayAskForTruckDetails()
        {
            return "";
        }

        public void GetVehicleInfoFromUser(Vehicle i_Vehicle, VehicleFactory.eVehicleType i_VehicleType)
        {
            string modelName;
            float energyUnits, airPressure;
            Dictionary<string,string> vehicleExtraInfo;

            VehiclePowerSystem vehiclePowerSystem = i_Vehicle.GetVehiclePowerSystem();
            CollectCommonVehicleInfoFromUser(i_Vehicle, out modelName, out energyUnits, out airPressure);

            vehicleExtraInfo = GetFurtherVehicleInfo(i_Vehicle);

        }

        public string GetManufacturerWheelName()
        {
            Console.WriteLine("what is the name of your vehicle wheels manufacturer?");
            return Console.ReadLine();
        }

        public Dictionary<string, string> GetFurtherVehicleInfo(Vehicle i_Vehicle)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            foreach (KeyValuePair<string, object> property in i_Vehicle.GetProperties())
            {
                Console.WriteLine($"Enter the value for {property.Key}:");
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
            input= Console.ReadLine();

            if(!float.TryParse(input, out wheelsAirPressure))
            {
                throw new FormatException();
            }
            return wheelsAirPressure;
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
            //we are not suppose to do that here
            //vehiclePowerSystem.AddEnergy(EnergySourceUnitsAvailable);
            return EnergySourceUnitsAvailable;
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
