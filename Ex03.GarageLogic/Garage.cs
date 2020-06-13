using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<GarageCustomer> customersList = new List<GarageCustomer>();


        //1 -Method - insert a new vehicle to the garage 
        public bool InsertVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_PhoneNumber)
        {
            GarageCustomer currentCustomer = FindVehicleInGarage(i_Vehicle.LicenseNumber);
            if (currentCustomer == null)
            {
                currentCustomer = new GarageCustomer();
                currentCustomer.Vehicle = i_Vehicle;
                currentCustomer.OwnerName = i_OwnerName;
                currentCustomer.PhoneNumber = i_PhoneNumber;
                currentCustomer.Status = eStatus.Repairing;
                customersList.Add(currentCustomer);
                return true;
            }
            else
            {
                currentCustomer.Status = eStatus.Repairing;
                return false;
            }
            
        }

        //2 -present a list of license plats of the vehicles in the garage
        public List<string> LicenseList( )
        {
            List<string> customers = new List<string>();

            foreach (GarageCustomer customer in customersList)
            {
                customers.Add(customer.Vehicle.LicenseNumber);
            }
            
            return customers;
        }

        public List<string> LicenseList(eStatus i_Status)
        {
            /*
            eStatus status;
            if(!Enum.TryParse(i_Status, out status))
            {
                throw new ArgumentException();
            }
            */

            List<string> customers = new List<string>();
          
            foreach (GarageCustomer customer in customersList)
            {
                if (customer.Status == i_Status)
                {
                    customers.Add(customer.Vehicle.LicenseNumber);
                }
            }
            return customers;

        }

        //3 -Method - changes the status of the specific vehicle in the garage - by license plate
        public void ChangeStatus(string i_LicenseNumber, eStatus i_NewStatus)
        {
            GarageCustomer currentCustomer = FindVehicleInGarage(i_LicenseNumber);
           
           
            if (currentCustomer != null)
            {
                currentCustomer.Status = i_NewStatus;
            }
            else
            {
                // throw exception 
            }
        }

        public void InflateToMax(string i_LicenseNumber)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            List<Wheel> wheelsToInflate = customer.Vehicle.Wheels;
            foreach(Wheel wheel in wheelsToInflate)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure); // inflates to the max 
            }
        }

        // 5- The method refuel vehicle on gas
        public void Refuel(string i_LicenseNumber, string i_FuelType, float i_FuelToAdd)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            GasTank gasTank = customer.Vehicle.GasTank;
            if (gasTank != null)
            {
                //(GasTank.Gas)Enum.Parse(typeof(GasTank.Gas), i_FuelType)
                //gasTank.GetType != i_FuelToAdd
                if (!gasTank.GasType.ToString().Equals(i_FuelType))
                {
                    throw new ArgumentException("Not the same fuel type", i_FuelType); // throw wrong gas exception
                }

                else
                {
                    try
                    {
                        gasTank.CurrentAmount += i_FuelToAdd;
                    }
                    catch(ValueOutOfRangeException outOfRange)
                    {
                        outOfRange = new ValueOutOfRangeException(gasTank.MaxCapacity, 0);//check - i gave the max fuel of the vehicle with the min amount
                        outOfRange.throwExceptionEror(i_FuelToAdd);// throws a message
                    }
                }

            }
            else
            {
                // throw wrong car exception
            }
        }

        // 6 - the method recharges the specific vehicle
        public void Recharge(string i_LicenseNumber, float i_TimeToAdd)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            Battery battery = customer.Vehicle.Battery;
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

        public  GarageCustomer FindVehicleInGarage(string i_LicensePlate)
        {
            GarageCustomer customerToReturn;
            foreach(GarageCustomer customer in customersList)
            {
                if(customer.Vehicle.LicenseNumber == i_LicensePlate)
                {
                    customerToReturn = customer;
                }
            }
            return null;

            
        }
       /* public void InflateWheel(Wheel[] i_Wheels, float i_Pressure)
        {
            for(int i = 0; i < i_Wheels.Length; i++)
            {
                i_Wheels[i].Inflate(i_Pressure);
            }  
        }*/
    }

    public enum eStatus{ Repairing, Fixed, Paid }
    public enum eDoorsAmount{ Two = 2, Three = 3, Four = 4, Five = 5 }
    public enum eColor{ Red,White,Black,Silver }
    public enum eLicense{ A, A1, AA, B }
    public enum eGasType{ Soler, Octan95, Octan96, Octan98 }
    public enum eVehicleType{ Car, ElectricCar, Motorcycle, ElectricMotorcycle, Truck }

}
