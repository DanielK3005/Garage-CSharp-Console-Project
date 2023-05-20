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


        //NEXT 2 FUNCTIONS ARE IN CONSTRUCTION
        public void DisplayAddNewVehicleMenu()
        {

            

            

            
        }

        public void GetVehicleTypeFromUser(out Vehicle.eVehicleType vehicleType)
        {
            do
            {
                Console.WriteLine("Enter the vehicle type:");
                PrintListOfVehicleTypes();

                int userInput;
                bool isValidInput = int.TryParse(Console.ReadLine(), out userInput);

                userInput -= 1;

                if (isValidInput && Enum.IsDefined(typeof(Vehicle.eVehicleType), userInput))
                {
                    vehicleType = (Vehicle.eVehicleType)userInput;
                    break;
                }

                Console.WriteLine("Invalid input. Please try again.");
            } while (true);
        }


        public void PrintListOfVehicleTypes()
        {
            int listItemCounter = 1;

            foreach (Vehicle.eVehicleType type in Enum.GetValues(typeof(Vehicle.eVehicleType)))
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

        public void GetVehicleInfoFromUser(Vehicle i_vehicle, Vehicle.eVehicleType i_VehicleType)
        {
            VehiclePowerSystem vehiclePowerSystem = i_vehicle.GetVehiclePowerSystem();
            Dictionary<string, string> vehicleInfo = CollectAndValidateCommonVehicleInfoFromUser(i_vehicle);

            //if(i_vehicle is Car)
            //{
            //    if(vehiclePowerSystem is InternalCombustionPowered)
            //    {

            //    }
            //    else if (vehiclePowerSystem is ElectricPowered)
            //    {

            //    }
            //}
            //else if(i_vehicle is Motorcycle)
            //{
            //    if (vehiclePowerSystem is InternalCombustionPowered)
            //    {

            //    }
            //    else if (vehiclePowerSystem is ElectricPowered)
            //    {

            //    }
            //}
            //else if(i_vehicle is Truck)
            //{

            //}

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.ElectricCar:
                    vehicleInfo.Add("Car Color", GetColorOfTheCarFromUser());
                    break;
                case Vehicle.eVehicleType.FuelCar:
                    vehicleInfo.Add("Car Color", GetColorOfTheCarFromUser());
                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:

                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:

                    break;
                case Vehicle.eVehicleType.Truck:

                    break;
            }

        }

        public Dictionary<string, string> CollectAndValidateCommonVehicleInfoFromUser(Vehicle i_vehicle)
        {
            Dictionary<string, string> vehicleInfo = new Dictionary<string, string>();
            vehicleInfo.Add("Model", GetFromTheUserTheVehicleModelName());
            vehicleInfo.Add("Energy Units", GetFromUserTheAmountEnergyUnitsAvailable(i_vehicle));
            vehicleInfo.Add("Wheels Air", GetAirPressureWheelsFromUser());

            return vehicleInfo;
        }

        public string GetColorOfTheCarFromUser()
        {
            string input;
            int choise;
            bool validinput = false;
            Console.WriteLine("what is the color of your car? (choose one option)");
            PrintListOfCarColors();
            input = Console.ReadLine();
            validinput = int.TryParse(input, out choise);
            choise -= 1;

            while(!validinput || choise < 0 || choise > 3)
            {
                Console.WriteLine("invalid input!");
                PrintListOfCarColors();
                input = Console.ReadLine();
                validinput = int.TryParse(input, out choise);
            }

            return Enum.GetName(typeof(Car.eCarColor), choise);
        }

        public void PrintListOfCarColors()
        {
            int listItemCounter = 1;

            foreach (Car.eCarColor color in Enum.GetValues(typeof(Car.eCarColor)))
            {
                Console.WriteLine("{0}. {1}", listItemCounter, color.ToString());
                listItemCounter++;
            }
        }

        public string GetAirPressureWheelsFromUser()
        {
            string input;
            float wheelsAirPressure;

            Console.WriteLine("what is your wheels air pressure? (insert one number which indicates your vehicle wheels air pressure)");
            input= Console.ReadLine();

            while(!float.TryParse(input, out wheelsAirPressure))
            {
                throw new FormatException("invalid input!\nthe format that you need to enter to air pressure is a number.");
            }
            return input;
        }

        public string GetFromUserTheAmountEnergyUnitsAvailable(Vehicle i_vehicle)
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
            return input;
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
