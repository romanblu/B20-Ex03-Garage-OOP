﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eColor color; // The color of the specific car
        private eDoorsAmount amountOfDoors; // The number of doors the car have

        public eColor Color { get { return color; } set { color = value; } }
        public eDoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public Car(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, eColor i_CarColor, eDoorsAmount i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            
            Dictionary<string, string> extraData = new Dictionary<string, string>();
            extraData.Add("Color", i_CarColor.ToString());
            extraData.Add("Number of doors", i_AmountOfDoors.ToString());
            ExtraTypeData = extraData;
            GasTank = new GasTank(eGasType.Octan96, 60);
            GasVehicle = true;
            this.color = i_CarColor;
            GasTank.CurrentAmount = EnergyLeft * GasTank.MaxCapacity;
            this.amountOfDoors = i_AmountOfDoors;
            for (int i = 0; i < 4; i++)
            {
                Wheels.Add(new Wheel(32));
            }
        }
   
    }
    
}
