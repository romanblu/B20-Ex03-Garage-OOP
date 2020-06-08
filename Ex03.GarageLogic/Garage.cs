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

        //Method - insert a new vehicle to the garage 
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

        //present a list of license plats of the vehicles in the garage
        public void LicenseList()
        {

        }

        //Method - changes the status of the specific vehicke in the garage - by license plate
        public void ChangeStatus(int i_LicenseNumber, Status i_NewStatus)
        {
            GarageCustomer currentCustomer = new GarageCustomer();//check
            foreach (GarageCustomer customer in this.customersList)
            {
                if (customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
                {
                    currentCustomer.status = i_NewStatus;
                }
            }
        }


        public void InflateToMax(int i_LicenseNumber)
        {
            GarageCustomer currentCustomer = new GarageCustomer();//check - לבדוק האם הכלי רכב יכול להיות גם רכב וגם אופנוע
            foreach (GarageCustomer customer in this.customersList)
            {
                if (customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
                {
                    for (int i = 0; i < currentCustomer.vehicle.vehicleWheels.Count; i++)
                    {
                        currentCustomer.vehicle.vehicleWheels[i].WheelAirBlowing(currentCustomer.vehicle.vehicleWheels[i].MaxAirPressure - currentCustomer.vehicle.vehicleWheels[i].CurrentAirPressure);
                    }

                }
            }
        }

        public void Refuel(int i_LicensePlate, string i_FuelType, float i_FuelToAdd)
        {

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
