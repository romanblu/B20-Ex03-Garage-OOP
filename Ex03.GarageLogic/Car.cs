﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private Color carColor;
        private DoorsAmount amountOfDoors;
        
        public Color CarColor{ get{return carColor;}set{this.carColor = value;} }
        public DoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public Car(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            this.carColor = (Color)Enum.Parse(typeof(Color), i_CarColor);

            this.amountOfDoors = (DoorsAmount)Enum.Parse(typeof(DoorsAmount), i_AmountOfDoors.ToString());
            base.GasTank = new GasTank(GasTank.Gas.Octan96, 60);
            base.GasVehicle = true;
            
            for(int i = 0; i < 4; i++)
            {
               
                base.Wheels.Add(new Wheel(32));
            }
        }
   
    }
    
}
