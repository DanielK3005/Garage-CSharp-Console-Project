using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UiManager
    {
        ConsoleUI m_ConsoleUI;
        GarageManager m_GarageLogic;

        public UiManager()
        {
            m_ConsoleUI = new ConsoleUI();
            m_GarageLogic = new GarageManager();
        }


        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("Garage Menu:");
                    Console.WriteLine("1. Add a new vehicle to the garage");
                    Console.WriteLine("2. Display the license numbers of vehicles in the garage");
                    Console.WriteLine("3. Change a vehicle's status");
                    Console.WriteLine("4. Inflate the wheels of a vehicle to maximum");
                    Console.WriteLine("5. Refuel a fuel-powered vehicle");
                    Console.WriteLine("6. Charge an electric vehicle");
                    Console.WriteLine("7. Display full vehicle information");
                    Console.WriteLine("8. Exit");
                    Console.Write("Please enter your choice (1-8): ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddVehicleIfNotExist();
                            break;
                        case "2":
                            DisplayLicenseNumbers();
                            break;
                        case "3":
                            //ChangeVehicleStatus();
                            break;
                        case "4":
                            InflateWheelsToMax();
                            break;
                        case "5":
                            //RefuelVehicle();
                            break;
                        case "6":
                            //ChargeVehicle();
                            break;
                        case "7":
                            //DisplayFullVehicleInformation();
                            break;
                        case "8":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }
        }



        //public void Run()
        //{
        //    string lisenceNumber;

        //    while (true)
        //    {
        //        lisenceNumber = m_ConsoleUI.GetLicensePlate();

        //        try
        //        {
        //            if (m_GarageLogic.IsVehicleInTheGarage(lisenceNumber))
        //            {
        //                m_ConsoleUI.DisplayVehicleAlreadyInTheGarage();
        //            }
        //            else
        //            {
        //                AddNewVehicle(lisenceNumber);

        //                Console.WriteLine(m_GarageLogic.GetAllVehiclesInformation());

        //                Console.ReadLine();
        //            }
        //        }
        //        catch(Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }
        //}

        public void InflateWheelsToMax()
        {
            string licensePlateNumber = m_ConsoleUI.GetLicensePlate();

            m_GarageLogic.InflateTheWheelsToMax(licensePlateNumber);


        }

        public void DisplayLicenseNumbers()
        {
            List<string> licensePlateNumbers;
            Vehicle.eVehicleStatus chosenStatus;

            chosenStatus = m_ConsoleUI.GetStatusFilterFromUser();
            licensePlateNumbers = m_GarageLogic.GetLicensePlateNumbers(chosenStatus);

            m_ConsoleUI.PrintListOfLicenseNumber(licensePlateNumbers, chosenStatus);

        }


        public void AddVehicleIfNotExist()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();
            if (m_GarageLogic.IsVehicleInTheGarage(lisenceNumber))
            {
                ChangeStatusToInRepairForExistingVehicleInGarage(lisenceNumber);
            }
            else
            {
                AddNewVehicle(lisenceNumber);
            }
        }

        public void ChangeStatusToInRepairForExistingVehicleInGarage(string i_LicenseNumber)
        {
            m_GarageLogic.ChangeVehicleGarageStatus(i_LicenseNumber, Vehicle.eVehicleStatus.InRepair);
            m_ConsoleUI.DisplayVehicleAlreadyInTheGarage();
        }

        public void AddNewVehicle(string i_LisenceNumber)
        {
            Vehicle newVehicle;
            Customer owner;
            string manufacturerWheelName, modelName;
            float energyUnits, airPressure;
            Dictionary<string, string> vehicleExtraInfo;

            m_ConsoleUI.DisplayVehicleDoesNotExists();

            owner = m_ConsoleUI.GetCustomerDetails();
            manufacturerWheelName = m_ConsoleUI.GetManufacturerWheelName();

            m_ConsoleUI.GetVehicleTypeFromUser(out VehicleFactory.eVehicleType vehicleType);

            newVehicle = m_GarageLogic.CreateNewVehicle(vehicleType, owner, manufacturerWheelName);

            m_ConsoleUI.GetVehicleInfoFromUser(newVehicle, vehicleType, out modelName, out energyUnits, out airPressure, out vehicleExtraInfo);
            m_GarageLogic.ValidateAndConfirmVehicleData(newVehicle, modelName, energyUnits, airPressure, vehicleExtraInfo, i_LisenceNumber);
            m_GarageLogic.AddVehicleToGarage(i_LisenceNumber, newVehicle);

            m_ConsoleUI.DisplayNewVehicleAdded(newVehicle);
        }

    }
}
