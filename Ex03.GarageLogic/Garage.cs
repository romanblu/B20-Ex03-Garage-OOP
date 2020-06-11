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
        private List<GarageCustomer> customersList = new List<GarageCustomer>();

        public bool VehicleExists(string i_LicenseNumber)
        {
            foreach( GarageCustomer customer in customersList)
            {

            }

            return false;
        }

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
        public List<string> LicenseList(string i_Status)
        {
            List<string> customers = new List<string>();
            if(i_Status != "")
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
        public void ChangeStatus(string i_LicenseNumber, string i_NewStatus)
        {
            GarageCustomer currentCustomer = FindCarInGarage(i_LicenseNumber);
            Status status;
            if(!Enum.TryParse(i_NewStatus, out status))
            {
                // wrong status value exception 
            } 
            
            if (currentCustomer != null)
            {
                currentCustomer.status = i_NewStatus;
            }
            else
            {
                // throw exception 
            }
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

        public  GarageCustomer FindCarInGarage(string i_LicensePlate)
        {
            GarageCustomer customerToReturn;
            foreach(GarageCustomer customer in customersList)
            {
                if(customer.vehicle.LicensePlate == i_LicensePlate)
                {
                    customerToReturn = customer;
                }
            }
            return null;

            
        }



        
        public enum Status
        {
            Repairing,
            Fixed,
            Paid
        }

    }
}
