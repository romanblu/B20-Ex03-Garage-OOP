using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasTank
    {
        private Gas gasType;
        private float currentAmount;
        private float maxCapacity;

        public Gas GasType { get { return this.gasType; } set { this.gasType = value; } }
        public float CurrentAmount { get { return this.currentAmount; } set { this.currentAmount = value; } }
        public float MaxCapacity { get { return this.maxCapacity; } set { this.maxCapacity = value; } }
        
        public GasTank(Gas i_GasType, float i_MaxCapacity)
        {
            this.gasType = i_GasType;
            this.maxCapacity = i_MaxCapacity;
        }

        public bool Refill(float i_FuelAmount, Gas i_GasType)
        {
            if(i_FuelAmount + this.currentAmount <= this.maxCapacity && i_GasType == this.gasType)
            {
                this.currentAmount += i_FuelAmount;
                return true;
            }
            return false;
        }

        public enum Gas
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }


    }
}
