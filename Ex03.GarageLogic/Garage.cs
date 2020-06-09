using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        //3 -Method - changes the status of the specific vehicle in the garage - by license plate
        public void ChangeStatus(int i_LicenseNumber, Status i_NewStatus)
        {
            GarageCustomer currentCustomer = new GarageCustomer();//check

            foreach (GarageCustomer customer in this.customersList)
            {
                if (customer.vehicle.LicensePlate.Equals(i_LicenseNumber.ToString()))
                {
                    currentCustomer.status = i_NewStatus;
                }
            } // add exception for which theres no such plate number 
        }

        public void InflateToMax(string i_LicenseNumber)
        {
            GarageCustomer customer = FindCarInGarage(i_LicenseNumber);
            List<Wheel> wheelsToInflate = customer.vehicle.Wheels;
            foreach(Wheel wheel in wheelsToInflate)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure); // inflates to the max 
            }
        }

        // 5- The method refuel vehicle on gas
        public void Refuel(string i_LicenseNumber, string i_FuelType, float i_FuelToAdd)
        {
            GarageCustomer customer = FindCarInGarage(i_LicenseNumber);
            GasTank gasTank = customer.vehicle.GasTank;
            if (gasTank != null)
            {
                if ((string)Enum.Parse(typeof(GasTank.Gas), gasTank.GasType) != i_FuelToAdd) 
                {
                    // throw wrong gas exception
                }
               if(gasTank.Amount + i_FuelToAdd <= gasTank.Capacity)
                {
                    gasTank.Amount += i_FuelToAdd;
                }
                else
                {
                    //throw too much gas exception
                }
            }
            else
            {
                // throw wrong car exception
            }
        }

        // 6 - the method recharges the specific vehicle
        public void Recharged(string i_LicenseNumber, float i_TimeToAdd)
        {
            GarageCustomer customer = FindCarInGarage(i_LicenseNumber);
            Battery battery = customer.vehicle.Battery;
            if (battery != null)
            {
                
                if (battery.TimeLeft + i_TimeToAdd <= battery.TimeCapacity)
                {
                    battery.TimeLeft += i_TimeToAdd;
                }
                else
                {
                    //throw overcharge exception
                }
            }
            else
            {
                // throw wrong car exception
            }
        }

        private  GarageCustomer FindCarInGarage(string i_LicensePlate)
        {
            GarageCustomer customerToReturn;
            foreach(GarageCustomer customer in customersList)
            {
                if(customer.vehicle.LicensePlate == i_LicensePlate)
                {
                    customerToReturn = customer;
                }
            }

            throw new Exception();
            // throw customer not found exception
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
