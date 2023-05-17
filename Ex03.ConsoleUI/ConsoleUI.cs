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

        
        public Vehicle DisplayAddNewVehicleMenu()
        {
            string vehicleType;

            Console.WriteLine("Choose your vehicle type: ");
            vehicleType = Console.ReadLine();

            
        }

        public void PrintListOfVehicleTypes()
        {

        }

        public string DisplayAskForFuelDetailsOfVehicle()
        {

        }

        public string DisplayAskForElectricDetailsOfVehicle()
        {

        }

        public string DisplayAskForCarDetails()
        {

        }

        public string DisplayAskForTruckDetails()
        {

        }

    }
}
