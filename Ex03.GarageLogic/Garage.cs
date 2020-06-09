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

        //1 -Method - insert a new vehicle to the garage 
        public bool InsertVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber, Status i_Status)
        {
            // we didnt insert the car successfully , well show a message in the UI
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
                return false; 
            }
            else
            {
                currentCustomer.vehicle = i_Vehicle;
                currentCustomer.ownerName = i_OwnerName;
                currentCustomer.phoneNumber = i_PhoneNumber;
                currentCustomer.status = i_Status;
                customersList.Add(currentCustomer);
                return true;

            }
            
        }

        //2 -present a list of license plats of the vehicles in the garage
        public List<string> LicenseList(Status i_Status)
        {
            List<string> customers = new List<string>();
            if(i_Status != null)
            {
                foreach(GarageCustomer customer in customersList)
                {
                    if(customer.status == i_Status)
                    {
                        customers.Add(customer.vehicle.LicensePlate);
                    }
                }
            }
            else
            {
                foreach(GarageCustomer customer in customersList)
                {
                    customers.Add(customer.vehicle.LicensePlate);
                }
            }
            return customers;
        }

        //3 -Method - changes the status of the specific vehicke in the garage - by license plate
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
                    List<Wheel> wheelsToInflate = customer.vehicle.Wheels;
                    foreach(Wheel wheel in wheelsToInflate)
                    {
                        wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure); // inflates to the max 
                    }
                }
            }
        }

        // 5- The method refuel vehicle on gas
        public void Refuel(int i_LicenseNumber, string i_FuelType, float i_FuelToAdd)
        {
            GarageCustomer currentCustomer = new GarageCustomer();
            foreach (GarageCustomer customer in this.customersList) 
            { 
              if (customer.vehicle is Car && customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString())) // if the current vehicle is A car on fuel
              {
                 
              }
              else if (currentCustomer.vehicle is Motorcycle && customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
              {

              }
              else if (currentCustomer.vehicle is Truck && customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
              {

              }
            }
        }

        // 6 - the method recharges the specific vehicle
        public void Recharged(int i_LicenseNumber, float i_FuelToAdd)
        {
            GarageCustomer currentCustomer = new GarageCustomer();
            foreach (GarageCustomer customer in this.customersList)
            {
                if (customer.vehicle is ElectricCar && customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString())) // if the current vehicle is A car on fuel
                {

                }
                else if (currentCustomer.vehicle is ElectricMotorcycle && customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
                {

                }
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
