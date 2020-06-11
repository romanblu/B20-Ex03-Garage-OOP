using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Battery
    {
        private float timeLeft;
        private float timeCapacity;

        public float TimeLeft { get { return timeLeft; } set { timeLeft = value; } }
        public float TimeCapacity { get { return timeCapacity; } set { timeCapacity = value; } }

        public Battery(float i_TimeCapacity)
        {
            this.timeLeft = timeCapacity; //the battery initializes with full capacity
            this.timeCapacity = i_TimeCapacity;
        }

        public bool Recharged(float i_HoursAmount) 
        {
            if (timeLeft + i_HoursAmount <= this.timeCapacity)
            {
                this.timeLeft += i_HoursAmount;
                return true;
            }   
            return false;
        }

    }
}
