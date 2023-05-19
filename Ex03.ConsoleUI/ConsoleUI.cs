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

            foreach (string type in Vehicle.r_VehicleType)
            {
                Console.WriteLine("{0}. {1}", listItemCounter, type);
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
            CollectAndValidateCommonVehicleInfoFromUser(i_vehicle);

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

                    break;
                case Vehicle.eVehicleType.FuelCar:

                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:

                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:

                    break;
                case Vehicle.eVehicleType.Truck:

                    break;
            }

        }

        public void CollectAndValidateCommonVehicleInfoFromUser(Vehicle i_vehicle)
        {
            GetFromTheUserTheVehicleModelName(i_vehicle);
            GetFromUserTheAmountEnergyUnitsAvailable(i_vehicle);
        }

        public void GetFromUserTheAmountEnergyUnitsAvailable(Vehicle i_vehicle)
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

            vehiclePowerSystem.AddEnergy(EnergySourceUnitsAvailable);
        }

        public void GetFromTheUserTheVehicleModelName(Vehicle i_vehicle)
        {
            string modelName;

            Console.WriteLine("Provide the model name of the vehicle: ");
            modelName = Console.ReadLine();
        }
    }
}
