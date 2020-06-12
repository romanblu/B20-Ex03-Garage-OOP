using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : Vehicle
    {
        private eColor carColor;
        private eDoorsAmount amountOfDoors;

        public eColor CarColor { get { return carColor; } set { this.carColor = value; } }
        
        public eDoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public ElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            base.GasVehicle = false;
            this.carColor = (eColor)Enum.Parse(typeof(eColor) , i_CarColor);
            this.amountOfDoors = (eDoorsAmount)i_AmountOfDoors;
            base.Battery = new Battery(2.1f);            

            for (int i = 0; i < 4; i++)
            {
                base.Wheels.Add(new Wheel(32));
            }
            
        }


    }
}
