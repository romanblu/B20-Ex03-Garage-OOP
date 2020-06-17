using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageCustomer
    {
       
        private Vehicle vehicle;
        private string ownerName;
        private string phoneNumber;
        private eStatus status;

        public Vehicle Vehicle { get { return vehicle; } set { vehicle = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { phoneNumber = value; } }
        public string OwnerName { get { return ownerName; } set { ownerName = value; } }
        public eStatus Status { get { return this.status; } set { this.status = value; } }

        public GarageCustomer()
        {

        }
        public GarageCustomer(Vehicle vehicle, string ownerName, string phoneNumber, eStatus status)
        {
            this.vehicle = vehicle;
            this.ownerName = ownerName;
            this.phoneNumber = phoneNumber;
            this.status = status;
        }

    }
}
