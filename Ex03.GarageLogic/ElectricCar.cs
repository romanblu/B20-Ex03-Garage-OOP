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
        private List<Wheel> wheels;
        private DoorsAmount numberOfDoors;
        private Battery battery = new Battery(2.1f);

        public Color CarColor { get { return carColor; } set { this.carColor = value; } }
        
        public DoorsAmount NumberOfDoors { get { return this.numberOfDoors; } set { this.numberOfDoors = value; } }
        
        public ElectricCar(string model, string licenseNumber, float energyLeft, List<Wheel> wheels, Color color, DoorsAmount numberOfDoors)
            : base(model, licenseNumber, energyLeft, wheels)
        {
            this.carColor = color;
            this.numberOfDoors = numberOfDoors;
            

            for (int i = 0; i < 4; i++)
            {
                wheels.Add(new Wheel(32));
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
