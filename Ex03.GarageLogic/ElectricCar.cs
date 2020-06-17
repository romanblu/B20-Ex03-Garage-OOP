using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Vehicle
    {
        private eColor carColor;// The spesific color of the car 
        private eDoorsAmount amountOfDoors;//The amount of doors of the specific car

        public eColor CarColor { get { return carColor; } set { this.carColor = value; } }
        
        public eDoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public ElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, eColor i_CarColor, eDoorsAmount i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            base.GasVehicle = false;
            this.carColor = i_CarColor;
            this.amountOfDoors = i_AmountOfDoors;
            base.Battery = new Battery(2.1f);            
            for (int i = 0; i < 4; i++)
            {
                base.Wheels.Add(new Wheel(32));
            }
            
        }


    }
}
