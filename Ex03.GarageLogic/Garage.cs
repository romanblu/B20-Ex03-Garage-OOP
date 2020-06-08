using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private List<GarageCustomer> customersList = new List<GarageCustomer>();

        public void InsertVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber, Status i_Status)
        {

            bool carExists = false;
            GarageCustomer currentCustomer = new GarageCustomer();
            foreach (GarageCustomer customer in customersList)
            {
                if (customer.vehicle.Model.Equals(i_Vehicle.Model))
                {
                    carExists = true;
                    currentCustomer = customer;
                }
            }
            if (carExists == true)
            {
                currentCustomer.status = Status.Repairing;
            }
            else
            {
                currentCustomer.vehicle = i_Vehicle;
                currentCustomer.ownerName = i_OwnerName;
                currentCustomer.phoneNumber = i_PhoneNumber;
                currentCustomer.status = i_Status;
                customersList.Add(currentCustomer);

            }
            
        }

        struct GarageCustomer
        {
            public Vehicle vehicle;
            public string ownerName;
            public string phoneNumber;
            public Status status;
        }
        public enum Status
        {
            Repairing,
            Fixed,
            Paid
        }

    }
}
