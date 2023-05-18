using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Vehicle;

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

        public void DisplayAddNewVehicleMenu()
        {
            string vehicleType;

            Console.WriteLine("Choose your vehicle type: ");
            Console.WriteLine();
            PrintListOfVehicleTypes();

            vehicleType = Console.ReadLine();

            
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

    }
}
