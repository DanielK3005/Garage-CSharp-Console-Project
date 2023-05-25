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
        private ConsoleUI m_ConsoleUI;
        private GarageManager m_GarageLogic;

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
                            addVehicleIfNotExist();
                            break;
                        case "2":
                            displayLicenseNumbers();
                            break;
                        case "3":
                            changeVehicleStatus();
                            break;
                        case "4":
                            inflateWheelsToMax();
                            break;
                        case "5":
                            refuelVehicle();
                            break;
                        case "6":
                            chargeVehicle();
                            break;
                        case "7":
                            displayFullVehicleInformation();
                            break;
                        case "8":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
                }
            }
        }

        private void inflateWheelsToMax()
        {
            string licensePlateNumber = m_ConsoleUI.GetLicensePlate();

            m_GarageLogic.InflateTheWheelsToMax(licensePlateNumber);

            m_ConsoleUI.DisplayInflatedWheelsToMax();

            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }

        private void displayLicenseNumbers()
        {
            List<string> licensePlateNumbers;
            Vehicle.eVehicleStatus chosenStatus;

            chosenStatus = m_ConsoleUI.GetVehicleStatusFromUser(true);
            licensePlateNumbers = m_GarageLogic.GetLicensePlateNumbers(chosenStatus);

            m_ConsoleUI.PrintListOfLicenseNumber(licensePlateNumbers, chosenStatus);
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();

        }

        private void refuelVehicle()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();
            InternalCombustionPowered.eFuelType fuelType = m_ConsoleUI.GetFromUserFuelTypeForRefuel();
            float fuelAmout = m_ConsoleUI.GetAmountOfFuelToRefuelFromUser();

            m_GarageLogic.RefuelVehicle(lisenceNumber, fuelType, fuelAmout);
            m_ConsoleUI.DisplayRefuelSucceeded();
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }

        private void chargeVehicle()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();
            float electricityAmount = m_ConsoleUI.GetAmountOfBatteryPercentageToChargeFromUser();

            m_GarageLogic.ChargeVehicle(lisenceNumber, electricityAmount);
            m_ConsoleUI.DisplayChargeSucceeded();
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }

        private void displayFullVehicleInformation()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();
            string vehicleInfo= m_GarageLogic.GetVehicleInformation(lisenceNumber);

            m_ConsoleUI.DisplayVehicleInformation(vehicleInfo);
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }

        private void changeVehicleStatus()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();

            Vehicle.eVehicleStatus newStatus = m_ConsoleUI.GetVehicleStatusFromUser(false);

            m_GarageLogic.ChangeVehicleGarageStatus(lisenceNumber, newStatus);

            m_ConsoleUI.DisplayVehicleStatusUpdated();
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }


        private void addVehicleIfNotExist()
        {
            string lisenceNumber = m_ConsoleUI.GetLicensePlate();
            if (m_GarageLogic.IsVehicleInTheGarage(lisenceNumber))
            {
                changeStatusToInRepairForExistingVehicleInGarage(lisenceNumber);
            }
            else
            {
                addNewVehicle(lisenceNumber);
            }
            m_ConsoleUI.pressAnyKeyToReturnToTheMenu();
        }

        private void changeStatusToInRepairForExistingVehicleInGarage(string i_LicenseNumber)
        {
            m_GarageLogic.ChangeVehicleGarageStatus(i_LicenseNumber, Vehicle.eVehicleStatus.InRepair);
            m_ConsoleUI.DisplayVehicleAlreadyInTheGarage();
        }

        private void addNewVehicle(string i_LisenceNumber)
        {
            Vehicle newVehicle;
            Customer owner;
            string manufacturerWheelName, modelName;
            float energyUnits, airPressure;
            Dictionary<string, string> vehicleExtraInfo;

            m_ConsoleUI.DisplayVehicleDoesNotExists();

            owner = m_ConsoleUI.GetCustomerDetails();
            modelName = m_ConsoleUI.GetFromTheUserTheVehicleModelName();

            m_ConsoleUI.GetVehicleTypeFromUser(out VehicleFactory.eVehicleType vehicleType);
            manufacturerWheelName = m_ConsoleUI.GetManufacturerWheelName();
            newVehicle = m_GarageLogic.CreateNewVehicle(vehicleType, owner, manufacturerWheelName);

            m_ConsoleUI.GetVehicleInfoFromUser(newVehicle, out energyUnits, out airPressure, out vehicleExtraInfo);
            m_GarageLogic.ValidateAndConfirmVehicleData(newVehicle, modelName, energyUnits, airPressure, vehicleExtraInfo, i_LisenceNumber);
            m_GarageLogic.AddVehicleToGarage(i_LisenceNumber, newVehicle);

            m_ConsoleUI.DisplayNewVehicleAddedWithInRepairStatus();
        }

    }
}
