﻿using Ex03.GarageLogic;
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

            Console.ReadLine();
        }
    }
}
