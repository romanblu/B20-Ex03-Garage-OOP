﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string manufacturerName; // The name of manufacturer of the wheels
        private float currentAirPressure; // The current air pressure there is in the wheels
        private float maxAirPressure; // The maximum air pressure that the manufacturer determined for the wheels 

        public string ManufacturerName { get { return this.manufacturerName; } set { this.manufacturerName = value; } }
        public float CurrentAirPressure { get { return this.currentAirPressure; } set { this.currentAirPressure = value; } }
        public float MaxAirPressure { get { return this.maxAirPressure; } set { this.maxAirPressure = value; } }

        public Wheel(float i_MaxAirPressure)
        {
            this.currentAirPressure = i_MaxAirPressure;
            this.maxAirPressure = i_MaxAirPressure;
            this.manufacturerName = "Wheeliams and sons";
        }


        public void Inflate(float i_AirPressureToAdd)
        {
            if(currentAirPressure + i_AirPressureToAdd <= maxAirPressure)
            {
                currentAirPressure += i_AirPressureToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(maxAirPressure - currentAirPressure, 0); // "The air pressure exceeded the maximum"

            }
        }
    }
}
