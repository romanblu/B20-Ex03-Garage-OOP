using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : Vehicle
    {
        private Color carColor;
        private DoorsAmount amountOfDoors;

        public Color CarColor { get { return carColor; } set { this.carColor = value; } }
        
        public DoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public ElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            base.GasVehicle = false;
            this.carColor = (Color)Enum.Parse(typeof(Color) , i_CarColor);
            this.amountOfDoors = (DoorsAmount)i_AmountOfDoors;
            base.Battery = new Battery(2.1f);            

            for (int i = 0; i < 4; i++)
            {
                base.Wheels.Add(new Wheel(32));
            }
            
        }



        public enum DoorsAmount
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
        }

        public enum Color
        {
            Red,
            White,
            Black,
            Silver 
        }
    }
}
