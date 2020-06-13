using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private eColor carColor;
        private eDoorsAmount amountOfDoors;
        
        public eColor CarColor{ get{return carColor;}set{this.carColor = value;} }
        public eDoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public Car(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            Dictionary<string, string> extraData = new Dictionary<string, string>();
            extraData.Add("Color", i_CarColor);
            extraData.Add("Number of doors", i_AmountOfDoors.ToString());
            base.ExtraTypeData = extraData;
            this.carColor = (eColor)Enum.Parse(typeof(eColor), i_CarColor);
            this.amountOfDoors = (eDoorsAmount)Enum.Parse(typeof(eDoorsAmount), i_AmountOfDoors.ToString());
            base.GasTank = new GasTank(eGasType.Octan96, 60);
            base.GasVehicle = true;
            
            for(int i = 0; i < 4; i++)
            {
                base.Wheels.Add(new Wheel(32));
            }
        }
   
    }
    
}
