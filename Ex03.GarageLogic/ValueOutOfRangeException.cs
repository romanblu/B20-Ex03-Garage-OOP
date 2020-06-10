using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
        public float MaxValueGet { get; } 
        public float MinValueGet { get; }


        public ValueOutOfRangeException(string message) : base(message)
        {

        }

        public ValueOutOfRangeException(string message, Exception inner) : base(message, inner)
        {

        }
        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)//check
        {
            this.MaxValue = i_MaxValue;
            this.MinValue = i_MinValue;
        }
        public ValueOutOfRangeException(string message, float i_MaxValue, float i_MinValue) : this(message)
        {
            this.MaxValue = i_MaxValue;
            this.MinValue = i_MinValue;
        } 

        public void throwExceptionEror(float i_CurrentValue)
        {
            if(i_CurrentValue < this.MinValue || i_CurrentValue > this.MaxValue)
            {
                throw new ValueOutOfRangeException("The value is out of range.", MaxValue, MinValue);
            }
        } 
    }
}
