 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float MaxValue;
        private float MinValue;
        public float MaxValueGet { get { return MaxValue; } } 
        public float MinValueGet { get { return MinValue; } }


        public ValueOutOfRangeException() {}
        public ValueOutOfRangeException(string message) : base(message) {}

        public ValueOutOfRangeException(string i_Message, Exception i_InnerException) : base(i_Message, i_InnerException) {}

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue) : base(string.Format("The value is out of range."))
        {

            this.MaxValue = i_MaxValue;
            this.MinValue = i_MinValue;
        }

    }
}
