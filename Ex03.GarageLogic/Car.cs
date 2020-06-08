using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private Color carColor;
        private DoorsAmount numberOfDoors;
        private GasTank gasTank = new GasTank(GasTank.Gas.Octan96, 60);
        private List<Wheel> wheels;
        public Color CarColor{ get{return carColor;}set{this.carColor = value;} }
        public DoorsAmount NumberOfDoors { get { return this.numberOfDoors; } set { this.numberOfDoors = value; } }

        
        public Car(string model, string licenseNumber, float energyLeft, Color color, DoorsAmount numberOfDoors)
            : base(model, licenseNumber, energyLeft)
        {
            this.carColor = color;
            this.numberOfDoors = numberOfDoors;
            gasTank = new GasTank(GasTank.Gas.Octan96, 60);
            
            for(int i = 0; i < 4; i++)
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
            Silver,
        }
    }
}
