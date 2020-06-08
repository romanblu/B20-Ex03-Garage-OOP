using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string manufacturerName;// The name of manufacturer of the wheels
        private float currentAirPressure;//The current air pressure there is in the wheels
        private float maxAirPressure;//The maximum air pressure that the manufacturer determined for the wheels 

        public Wheel(float i_MaxAirPressure)
        {
            this.currentAirPressure = maxAirPressure; 
            this.maxAirPressure = i_MaxAirPressure;
        }

        //Construct a wheel
        public Wheel(float i_CurrentAirPressure, float i_MaxAirPressure, string i_ManufacturerName)
        {
            this.currentAirPressure = i_CurrentAirPressure;
            this.maxAirPressure = i_MaxAirPressure;
            this.manufacturerName = i_ManufacturerName;
        }
        public static void Inflate(float i_AirPressureToAdd)
        {
            // the method wiil change the current air pressure while its not acceding the max air pressure.
        }
    }
}
