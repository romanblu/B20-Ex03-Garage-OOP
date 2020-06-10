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
        public float MaxValueGet {get;} 
        public float MinValueGet {get;}

        public ValueOutOfRangeException()
        {

        }

        public ValueOutOfRangeException(string message) : base(message)
        {

        }

        public ValueOutOfRangeException(string message, Exception inner) : base(message, inner)
        {

        }
        public ValueOutOfRangeException(string message, float i_MaxValue, float i_MinValue) : this(message)
        {

        } 
    }
}
