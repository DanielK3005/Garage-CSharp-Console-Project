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

                if (m_GarageLogic.IsVehicleInTheGarage(lisenceNumber))
                {
                    m_ConsoleUI.DisplayVehicleAlreadyInTheGarage();
                }
                else
                {
                    AddNewVehicle();
                }
            }
        }


        public void AddNewVehicle()
        {
            m_ConsoleUI.DisplayVehicleDoesNotExists();
            m_ConsoleUI.DisplayAddNewVehicleMenu();
        }

    }
}
