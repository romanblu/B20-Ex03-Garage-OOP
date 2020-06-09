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
       
        private DoorsAmount numberOfDoors;

        public Color CarColor { get { return carColor; } set { this.carColor = value; } }
        
        public DoorsAmount NumberOfDoors { get { return this.numberOfDoors; } set { this.numberOfDoors = value; } }
        
        public ElectricCar(string model, string licenseNumber, float energyLeft, string color, int numberOfDoors)
            : base(model, licenseNumber, energyLeft)
        {
            base.GasVehicle = false;
            this.carColor = (Color)Enum.Parse(typeof(Color) ,color);
            this.numberOfDoors = (DoorsAmount)numberOfDoors;
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
