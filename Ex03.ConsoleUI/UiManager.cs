using System;
using System.Collections.Generic;
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
            string lisenceNumber;

            while (true)
            {
                lisenceNumber = m_ConsoleUI.GetLicensePlate();

                try
                {
                    if (m_GarageLogic.IsVehicleInTheGarage(lisenceNumber))
                    {
                        m_ConsoleUI.DisplayVehicleAlreadyInTheGarage();
                    }
                    else
                    {
                        AddNewVehicle(lisenceNumber);

                        Console.WriteLine(m_GarageLogic.GetAllVehiclesInformation());

                        Console.ReadLine();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        public void AddNewVehicle(string i_LisenceNumber)
        {
            Vehicle newVehicle;
            Customer owner;
            string manufacturerWheelName, modelName;
            float energyUnits, airPressure;
            Dictionary<string, string> vehicleExtraInfo;

            m_ConsoleUI.DisplayVehicleDoesNotExists();
            //m_ConsoleUI.DisplayAddNewVehicleMenu();

            owner = m_ConsoleUI.GetCustomerDetails();
            manufacturerWheelName = m_ConsoleUI.GetManufacturerWheelName();

            m_ConsoleUI.GetVehicleTypeFromUser(out VehicleFactory.eVehicleType vehicleType);

            newVehicle = m_GarageLogic.CreateNewVehicle(vehicleType, owner, manufacturerWheelName);

            m_ConsoleUI.GetVehicleInfoFromUser(newVehicle, vehicleType, out modelName, out energyUnits, out airPressure, out vehicleExtraInfo);
            m_GarageLogic.ValidateAndConfirmVehicleData(newVehicle, modelName, energyUnits, airPressure, vehicleExtraInfo, i_LisenceNumber);
            m_GarageLogic.AddVehicleToGarage(i_LisenceNumber, newVehicle);
        }

    }
}
