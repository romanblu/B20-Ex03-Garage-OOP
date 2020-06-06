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
        private float amount;
        private float capacity;

        public Gas GasType { get { return this.gasType; } set { this.gasType = value; } }
        public float Amount { get { return this.amount; } set { this.amount = value; } }
        public float Capacity { get { return this.capacity; } set { this.capacity = value; } }
        
        public GasTank(Gas gasType, float capacity)
        {
            this.gasType = gasType;
            this.capacity = capacity;
        }

        public bool Refill(float i_FuelAmount, Gas i_GasType)
        {
            if(i_FuelAmount + this.amount <= this.capacity && i_GasType == this.gasType)
            {
                this.amount += i_FuelAmount;
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
