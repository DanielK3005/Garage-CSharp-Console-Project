using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            UiManager uiManager = new UiManager();
            uiManager.Run();

            //Car myCar = new Car(null, VehicleFactory.eVehicleType.ElectricCar, null);

            //Dictionary<string, object> carProperties = myCar.GetPropertiesDictionary();

            //// Create a dictionary to store the chosen values
            //Dictionary<string, string> chosenProperties = new Dictionary<string, string>();

            //// Prompt the user to choose values for each property
            //foreach (KeyValuePair<string, object> property in carProperties)
            //{
            //    Console.WriteLine($"Available options for {property.Key}:");
            //    foreach (var option in (Array)property.Value)
            //    {
            //        Console.WriteLine(option);
            //    }
            //    Console.WriteLine($"Choose an option for {property.Key}:");
            //    string chosenValue = Console.ReadLine();
            //    chosenProperties[property.Key] = chosenValue;
            //    Console.WriteLine();
            //}

            //// Assign and validate the chosen properties
            //myCar.AssignAndValidateProperties(chosenProperties);

            Console.ReadLine();
        }
    }
}
