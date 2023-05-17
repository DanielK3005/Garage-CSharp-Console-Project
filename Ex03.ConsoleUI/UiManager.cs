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
        }

        public void Run()
        {
            string lisenceNumber;

            while (true)
            {
                lisenceNumber = m_ConsoleUI.GetLicensePlate();

            }
        }


    }
}
