﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex3.ConsoleUI
{
   public class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            GarageUI ui = new GarageUI(garage);
            ui.GarageFunctions(); 
          }
    }
}
