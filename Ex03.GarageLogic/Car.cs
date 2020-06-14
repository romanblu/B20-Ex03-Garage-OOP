using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private eColor color;
        private eDoorsAmount amountOfDoors;
        
        public eColor Color{ get{return color;}set{ color = value;} }
        public eDoorsAmount NumberOfDoors { get { return this.amountOfDoors; } set { this.amountOfDoors = value; } }
        
        public Car(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, eColor i_CarColor, eDoorsAmount i_AmountOfDoors)
            : base(i_ModelName, i_LicensePlate, i_EnergyLeft)
        {
            
            Dictionary<string, string> extraData = new Dictionary<string, string>();
            extraData.Add("Color", i_CarColor.ToString());
            extraData.Add("Number of doors", i_AmountOfDoors.ToString());
            base.ExtraTypeData = extraData;
            base.GasTank = new GasTank(eGasType.Octan96, 60);
            base.GasVehicle = true;

            //this.color = (eColor)Enum.Parse(typeof(eColor), i_CarColor);// formatexcecption
            //this.amountOfDoors = (eDoorsAmount)Enum.Parse(typeof(eDoorsAmount), i_AmountOfDoors.ToString());// formatexcecption
            this.color = i_CarColor;
            this.amountOfDoors = i_AmountOfDoors;
            for (int i = 0; i < 4; i++)
            {
                base.Wheels.Add(new Wheel(32));
            }
        }
   
    }
    
}
