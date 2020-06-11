using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageCustomer
    {
       
        public Vehicle vehicle;
        public string ownerName;
        public string phoneNumber;
        public string status;
         public GarageCustomer()
        {

        }
        public GarageCustomer(Vehicle vehicle, string ownerName, string phoneNumber, string status)
        {
            this.vehicle = vehicle;
            this.ownerName = ownerName;
            this.phoneNumber = phoneNumber;
            this.status = status;
        }

    }
}
