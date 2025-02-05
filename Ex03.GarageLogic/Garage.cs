﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        public List<GarageCustomer> CustomersList = new List<GarageCustomer>();

        // 1 -Method - insert a new vehicle to the garage 
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
                CustomersList.Add(currentCustomer);
                return true;
            }
            else
            {
                currentCustomer.Status = eStatus.Repairing;
                return false;
            }
        }

        // 2 Method-present a list of license numbers of the vehicles in the garage
        public List<string> LicenseList()
        {
            List<string> customers = new List<string>();
            foreach (GarageCustomer customer in CustomersList)
            {
                customers.Add(customer.Vehicle.LicenseNumber);
            }
            
            return customers;
        }

        public List<string> LicenseList(eStatus i_Status)
        {
            List<string> customers = new List<string>();
          
            foreach (GarageCustomer customer in CustomersList)
            {
                if (customer.Status == i_Status)
                {
                    customers.Add(customer.Vehicle.LicenseNumber);
                }
            }
            return customers;
        }

        // 3 -Method - changes the status of the specific vehicle in the garage - by license plate
        public void ChangeStatus(string i_LicenseNumber, eStatus i_NewStatus)
        {
            GarageCustomer currentCustomer = FindVehicleInGarage(i_LicenseNumber);
            if (currentCustomer != null)
            {
                currentCustomer.Status = i_NewStatus;
            }
            else
            {
                throw new ArgumentException("No such vehicle found");
            }
            
        }
         
        // 4 Method - Inflate wheels to max
        public void InflateToMax(string i_LicenseNumber)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            List<Wheel> wheelsToInflate = customer.Vehicle.Wheels;
            foreach(Wheel wheel in wheelsToInflate)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure); // inflates to the max 
            }
        }

        // 5 Method- The method refuel vehicle on gas
        public void Refuel(string i_LicenseNumber, eGasType i_FuelType, float i_FuelToAdd)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            GasTank gasTank = customer.Vehicle.GasTank;
            

            if (gasTank != null)
            {
                
                if (!gasTank.GasType.ToString().Equals(i_FuelType.ToString()))
                {
                    
                    throw new ArgumentException("Wrong fuel type"); // throw wrong gas exception.  
                }

                else
                {
                    if(i_FuelToAdd < 0 || i_FuelToAdd > gasTank.MaxCapacity - gasTank.CurrentAmount)
                    {
                        throw new ValueOutOfRangeException(gasTank.MaxCapacity - gasTank.CurrentAmount, 0);

                    }
                    
                    else
                    {
                        gasTank.CurrentAmount += i_FuelToAdd;
                        customer.Vehicle.EnergyLeft = gasTank.CurrentAmount / gasTank.MaxCapacity;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Cannot refuel with gas an electric vehicle");
            }
        }

        // 6 Method- the method recharges the specific vehicle
        public void Recharge(string i_LicenseNumber, float i_TimeToAdd)
        {
            GarageCustomer customer = FindVehicleInGarage(i_LicenseNumber);
            Battery battery = customer.Vehicle.Battery;
            if (battery != null)
            {   
                
                if(i_TimeToAdd < 0 || i_TimeToAdd > battery.TimeCapacity)
                {
                   throw new ValueOutOfRangeException(battery.TimeCapacity - battery.TimeLeft, 0);
                }

                else
                {
                    battery.TimeLeft += i_TimeToAdd;
                    customer.Vehicle.EnergyLeft = battery.TimeLeft / battery.TimeCapacity;
                }
            }
            else
            {
                throw new ArgumentException("Cannot recharge gas vehicle");
            }
        }

        public GarageCustomer FindVehicleInGarage(string i_LicensePlate)
        {
            GarageCustomer customerToReturn;
            foreach(GarageCustomer customer in CustomersList)
            {
                if(customer.Vehicle.LicenseNumber == i_LicensePlate)
                {
                    customerToReturn = customer;
                    return customerToReturn;
                }
            }

            return null;   
        }
    }

    public enum eStatus { Repairing, Fixed, Paid }
    public enum eDoorsAmount { Two = 2, Three = 3, Four = 4, Five = 5 }
    public enum eColor
    { Red, White, Black, Silver }
    public enum eLicense { A, A1, AA, B }
    public enum eGasType { Soler, Octan95, Octan96, Octan98 }
    public enum eVehicleType { Car = 1, ElectricCar = 2, Motorcycle = 3, ElectricMotorcycle = 4, Truck = 5 }

}
