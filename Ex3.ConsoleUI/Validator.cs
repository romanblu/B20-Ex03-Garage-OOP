using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
    public class Validator
    {

        public void ValidateWheelsPressure(List<Wheel> i_Wheels)
        {

            Console.WriteLine("All wheels inflated to the max, enter \"yes\" if you want to change the pressure or enter to leave it at max");
            string inputString = Console.ReadLine();
            if (inputString == "yes")
            {
                Console.WriteLine("To change air pressure to all wheels enter \'All\' or press Enter to change individually");
                inputString = Console.ReadLine();
                if (inputString == "")
                {
                    for (int i = 0; i < i_Wheels.Count; i++)
                    {
                        Console.WriteLine("Enter air pressure value for wheel #{0}", i + 1);
                        inputString = Console.ReadLine();
                        float airPressure;
                        while (!float.TryParse(inputString, out airPressure) || airPressure < 0 || airPressure > i_Wheels[i].MaxAirPressure)
                        {
                            Console.WriteLine("Enter a valid input number between 0 and " + i_Wheels[i].MaxAirPressure);
                            inputString = Console.ReadLine();
                        }

                        i_Wheels[i].CurrentAirPressure = airPressure;
                    }
                }
                else
                {
                    if (inputString == "All")
                    {
                        Console.WriteLine("Enter air pressure value for all wheels");
                        inputString = Console.ReadLine();
                        float airPressure;
                        while (!float.TryParse(inputString, out airPressure) || float.Parse(inputString) < 0 || float.Parse(inputString) > i_Wheels[0].MaxAirPressure)
                        {
                            Console.WriteLine("Enter a valid input number between 0 and " + i_Wheels[0].MaxAirPressure);
                            inputString = Console.ReadLine();
                        }

                        for (int i = 0; i < i_Wheels.Count; i++)
                        {
                            i_Wheels[i].CurrentAirPressure = airPressure;
                        }
                    }

                }

            }

        }


        public float ValidateEnergyLeft(string i_InputToCheck)
        {
            float energyLeft;
            while (!float.TryParse(i_InputToCheck, out energyLeft) || (energyLeft < 0 || energyLeft > 1))
            {
                Console.WriteLine("Please enter a valid value between 0 and 1");
                i_InputToCheck = Console.ReadLine();
            }
            return energyLeft;
        }

        public TEnum ValidateEnumType<TEnum>(string i_InputToCheck) where TEnum : struct
        {
            TEnum parsedEnum;
            while (!Enum.TryParse<TEnum>(i_InputToCheck, out parsedEnum) || !Enum.IsDefined(typeof(TEnum), parsedEnum))
            {
                StringBuilder enumListing = new StringBuilder();

                for (int i = 0; i < Enum.GetNames(parsedEnum.GetType()).Length; i++)
                {
                    enumListing.Append(Enum.GetNames(parsedEnum.GetType())[i]);
                    if (i != Enum.GetNames(parsedEnum.GetType()).Length - 1)
                    {
                        enumListing.Append(", ");
                    }
                }
                
                Console.WriteLine("Wrong value please choose from the options: " + enumListing.ToString());
                i_InputToCheck = Console.ReadLine();
            }
            return parsedEnum;
        }

        public GarageCustomer ValidateVehicleInGarage(string i_LicenseNumber, Garage i_Garage)
        {

            GarageCustomer currentCustomer = i_Garage.FindVehicleInGarage(i_LicenseNumber);
            while (currentCustomer == null)
            {
                Console.WriteLine("Couldnt find a vehicle with this license number, enter again");
                i_LicenseNumber = Console.ReadLine();
                currentCustomer = i_Garage.FindVehicleInGarage(i_LicenseNumber);
            }

            return currentCustomer;
        }

        public float ValidateWheelInfaltion(Wheel i_Wheel, string i_AirPressure)
        {
            float airPressure = 0;
            bool valid = false;
            while (!valid)
            {
                valid = true;


                if (!float.TryParse(i_AirPressure, out airPressure))
                {
                    valid = false;
                    Console.WriteLine("Enter a valid input, positive number ");
                    i_AirPressure = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        i_Wheel.Inflate(airPressure);
                    }
                    catch (ValueOutOfRangeException e)
                    {
                        valid = false;
                        Console.WriteLine("Cannot inflate wheel, try again " + e.MaxValueGet);
                        i_AirPressure = Console.ReadLine();
                    }

                }

            }
            return airPressure;

        }

        public Vehicle ValidateExtraDataForVehicleType(CreateNewVehicle i_Factory, eVehicleType i_VehicleType)
        {
            List<string> extraData = new List<string>();
            Vehicle currentVehicle = null;
            bool correctInput = false;
            while (!correctInput)
            {
                correctInput = true;
                extraData = i_Factory.GetExtraData(i_VehicleType);
                for (int i = 0; i < extraData.Count; i++)
                {
                    Console.WriteLine("Enter additional information about your " + i_VehicleType);
                    Console.WriteLine("Enter " + extraData[i].ToLower());
                    extraData[i] = Console.ReadLine();

                }
                try
                {
                    currentVehicle = i_Factory.FinishProduction(extraData);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again");
                    correctInput = false;
                }

            }
            return currentVehicle;
        }

        public void ValidateRefuel(eGasType i_GasType, string i_FuelAmount, string i_LicenseNumber, Garage i_Garage)
        {

            float amountToAdd;
            bool valid = false;
            while (!valid)
            {
                valid = true;
                while (!float.TryParse(i_FuelAmount, out amountToAdd) || amountToAdd < 0)
                {
                    Console.WriteLine("Please enter a valid numerical value for the amount ");
                    i_FuelAmount = Console.ReadLine();
                }
                try
                {
                    i_Garage.Refuel(i_LicenseNumber, i_GasType, amountToAdd);
                }
                catch (ArgumentException)
                {
                    valid = false;
                    Console.WriteLine("You entered wrong fuel type, please enter correct type");
                    i_GasType = ValidateEnumType<eGasType>(Console.ReadLine());
                }
                catch (ValueOutOfRangeException outOfRange)
                {
                    valid = false;
                    Console.WriteLine("Couldn't refuel, please enter value between {0} and {1}", outOfRange.MinValueGet, outOfRange.MaxValueGet);
                    i_FuelAmount = Console.ReadLine();
                }

            }
        }


        public void ValidateRecharge(string i_MinutesToAdd, string i_LicenseNumber, Garage i_Garage)
        {
            bool valid = false;
            while (!valid)
            {
                valid = true;
                int numberOfMinutes;
                while (!int.TryParse(i_MinutesToAdd, out numberOfMinutes) || numberOfMinutes < 0)
                {
                    Console.WriteLine("Enter valid input ");
                    i_MinutesToAdd = Console.ReadLine();
                }

                try
                {
                    i_Garage.Recharge(i_LicenseNumber, numberOfMinutes);
                }

                catch (ValueOutOfRangeException outOfRange)
                {
                    valid = false;
                    Console.WriteLine("Over charging, please enter between {0} and {1} minutes", outOfRange.MinValueGet * 60, outOfRange.MaxValueGet * 60);

                }

            }
        }
    }
}
