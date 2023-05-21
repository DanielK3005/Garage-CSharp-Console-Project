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
                        AddNewVehicle();

                        Console.ReadLine();
                    }
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        public void AddNewVehicle()
        {
            Vehicle newVehicle;
            Customer owner;

            m_ConsoleUI.DisplayVehicleDoesNotExists();
            //m_ConsoleUI.DisplayAddNewVehicleMenu();

            owner = m_ConsoleUI.GetCustomerDetails();

            m_ConsoleUI.GetVehicleTypeFromUser(out VehicleFactory.eVehicleType vehicleType);

            newVehicle = m_GarageLogic.CreateNewVehicle(vehicleType, owner);

            //m_ConsoleUI.GetVehicleInfoFromUser(newVehicle, vehicleType);

            //m_GarageLogic.AddVehicleToGarage(newVehicle);
        }

    }
}
