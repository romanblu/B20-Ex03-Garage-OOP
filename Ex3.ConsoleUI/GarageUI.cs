using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex3.ConsoleUI
{
   public  class GarageUI
    {
        Garage garage = new Garage();
        CreateNewVehicle factory = new CreateNewVehicle();
        List<Vehicle> userVehicles = new List<Vehicle>();
        Validator validator = new Validator();

        public GarageUI(Garage i_Garage)
        {
            this.garage = i_Garage;
        }

        public GarageUI() { }

        public void GarageFunctions()
        {
            Console.WriteLine("Hello, please choose you option from the list below:");
            StringBuilder functionsList = new StringBuilder();
            functionsList.AppendLine("0 - Create you vehicle ");
            functionsList.AppendLine("1 - to enter your car to the garage");
            functionsList.AppendLine("2 - List the vehicles in the garage");
            functionsList.AppendLine("3 - Change vehicle status from the list: " + ListEnumOptions(new eStatus()));
            functionsList.AppendLine("4 - Inflate wheels to max");
            functionsList.AppendLine("5 - Refuel gas vehicle");
            functionsList.AppendLine("6 - Recharge electric vehicle");
            functionsList.AppendLine("7 - To get full info about your vehicle");
            Console.WriteLine(functionsList.ToString());

            string inputOption = Console.ReadLine();
            int option;
            if (int.TryParse(inputOption, out option))
            {
                switch (option)
                {
                    case 0:
                        CreateVehicle();
                        break;
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        ShowVehicles();
                        break;
                    case 3:
                        ChangeStatus();
                        break;
                    case 4:
                        InflateWheelsToMax();
                        break;
                    case 5:
                        Refuel();
                        break;
                    case 6:
                        Recharge();
                        break;
                    case 7:
                        ShowInfo();
                        break;
                    default:
                        Console.WriteLine("Please enter a number from 0 to 7");
                        GarageFunctions();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number from 0 to 7");
                GarageFunctions();
            }
        }
        public string ListEnumOptions(Enum i_Enum)
        {
            StringBuilder enumListing = new StringBuilder();

            for (int i = 0; i < Enum.GetNames(i_Enum.GetType()).Length; i++)
            {
                enumListing.Append(Enum.GetNames(i_Enum.GetType())[i]);
                if (i != Enum.GetNames(i_Enum.GetType()).Length - 1)
                {
                    enumListing.Append(", ");
                }
            }
            return enumListing.ToString();
        }

        private Vehicle GetUserVehicle(string i_LicenseNumber)
        {
            foreach (Vehicle vehicle in userVehicles)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    return vehicle;
                }
            }
            return null;
        }

        // Method #0
        public void CreateVehicle()
        {
            Vehicle currentVehicle;
            Console.WriteLine("Enter model name");
            string modelName = Console.ReadLine();
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine("Enter energy left");
            string inputString = Console.ReadLine();
            float energyLeft = validator.ValidateEnergyLeft(inputString);

            Console.WriteLine("Enter vehicle type");
            inputString = Console.ReadLine();  
            eVehicleType vehicleType = validator.ValidateEnumType<eVehicleType>(inputString);
            
            factory.VehicleInProduction(vehicleType, modelName, licenseNumber, energyLeft);
            currentVehicle = validator.ValidateExtraDataForVehicleType(factory, vehicleType);
          

            Console.WriteLine("All wheels inflated to the max, enter \"yes\" if you want to change the pressure or enter to leave it at max");
            inputString = Console.ReadLine();
            if(inputString == "yes")
            { 
                Console.WriteLine("To change air pressure to all wheels press All or press Enter to change individually");
                inputString = Console.ReadLine();
                if (inputString == "")
                {
                    for(int i = 0; i < currentVehicle.Wheels.Count; i++)
                    {
                        Console.WriteLine("Enter air pressure value for wheel #{0}", i + 1);
                        float airPressure;
                        float.TryParse(Console.ReadLine(), out airPressure);//formatexception
                        try
                        {
                            currentVehicle.Wheels[i].Inflate(airPressure);
                        }
                        catch (ValueOutOfRangeException outOfRange)
                        {
                            Console.WriteLine(outOfRange.Message);
                            Console.WriteLine("Couldn't inflate wheel");
                        }

                    } 
                }
                else
                {
                    if(inputString == "All")
                    {
                        Console.WriteLine("Enter air pressure value for all wheels");
                        float airPressure;
                        float.TryParse(Console.ReadLine(), out airPressure);
                        for (int i = 0; i < currentVehicle.Wheels.Count; i++)
                        {
                            try
                            {
                                currentVehicle.Wheels[i].Inflate(airPressure);
                            }
                            catch (ValueOutOfRangeException outOfRange)
                            {
                                Console.WriteLine(outOfRange.Message);
                                Console.WriteLine("Couldn't inflate wheel");
                            }
                       
                        }
                    }
                    
                }

            }

            userVehicles.Add(currentVehicle);
            Console.WriteLine("The vehicle added successfully" + Environment.NewLine);
            GarageFunctions();
        }

        // Method #1
        private void AddVehicle()
        {
            Vehicle currentVehicle;
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            currentVehicle = GetUserVehicle(licenseNumber);
            if (currentVehicle == null)
            {
                Console.WriteLine("You didnt create vehicle with such license number, press 0 and create it" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Enter owner name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Enter phone number");
                string phoneNumber = Console.ReadLine();
                if (garage.InsertVehicle(currentVehicle, ownerName, phoneNumber))
                {
                    Console.WriteLine("Vehicle was inserted successfuly" + Environment.NewLine);
                    GarageFunctions();
                }
                else
                {
                    Console.WriteLine("Vehicle already in the garage, updated status to Repairing");
                }
            }
            GarageFunctions();
        }

        // Method #2 
        private void ShowVehicles()
        {
            Console.WriteLine("Insert the status you want to screen by, or press enter");            
            string input = Console.ReadLine();
            List<string> customers;
            if (input.Equals(""))
            {
                customers = garage.LicenseList();
            }
            else
            {
                eStatus status = validator.ValidateEnumType<eStatus>(input);
                customers = garage.LicenseList(status);    
            }
            
            StringBuilder customersList = new StringBuilder();
            foreach(string licenseNumber in customers)
            {
                customersList.AppendLine(licenseNumber);
            }
            Console.WriteLine(customersList);
            Console.WriteLine("Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        //Method #3
        private void ChangeStatus()
        {
            Console.WriteLine("Enter license number");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            Console.WriteLine("Enter status");
            string input = Console.ReadLine();
            eStatus status = validator.ValidateEnumType<eStatus>(input);
            garage.ChangeStatus(licenseNumber, status);
            Console.WriteLine("Status changed succesfully, Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        // Method #4
        private void InflateWheelsToMax()
        {
            Console.WriteLine("Enter license number to inflate wheels");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            garage.InflateToMax(licenseNumber);
            Console.WriteLine("Wheels inflated succesfully, Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }

        // Method #5 
        public void Refuel()
        {
            Console.WriteLine("Enter license number to refuel");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            Console.WriteLine("Enter fuel type");
            string input = Console.ReadLine();
            eGasType gasType = validator.ValidateEnumType<eGasType>(input);
            Console.WriteLine("Enter amount to fill");
            float amountToAdd;
            input = Console.ReadLine();
            while (!float.TryParse(input, out amountToAdd) || amountToAdd < 0)
            {
                Console.WriteLine("Please enter a valid numerical value for the amount ");
                input = Console.ReadLine();
            }
            try 
            {
                garage.Refuel(licenseNumber, gasType, amountToAdd);
            }
            catch (ValueOutOfRangeException outOfRange)
            {
                Console.WriteLine(outOfRange.Message);
                Console.WriteLine("Couldn't refuel");
            }
            catch (ArgumentException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Couldnt refuel vehicle");
            }
            finally
            {
                Console.WriteLine("Press anything to get back to main screen");
                Console.ReadLine();
                GarageFunctions();
            }
        }

        // Method #6
        public void Recharge()
        {
            Console.WriteLine("Enter license number to recharge");
            string licenseNumber = Console.ReadLine();
            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);
            Console.WriteLine("Enter number of minutes you want to recharge");
            int numberOfMinutes;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out numberOfMinutes) || numberOfMinutes < 0)
            {
                Console.WriteLine("Enter valid integer");
                input = Console.ReadLine();
            }

            try
            {
                garage.Recharge(licenseNumber, (float)numberOfMinutes / 60);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Couldnt recharge vehicle");
            }
            finally
            {
                Console.WriteLine("Press anything to get back to main screen");
                Console.ReadLine();
                GarageFunctions();
            }
        }

        // Method #7 
        public void ShowInfo()
        {
            Console.WriteLine("Enter license number to get vehicle info");
            string licenseNumber = Console.ReadLine();

            GarageCustomer currentCustomer = validator.ValidateVehicleInGarage(licenseNumber, garage);

            Vehicle vehicle = currentCustomer.Vehicle;
            
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.Append("License number: "+ licenseNumber + Environment.NewLine);
            vehicleInfo.Append("Model name: " + vehicle.Model + Environment.NewLine);// model name
            vehicleInfo.Append("Owner name: " + currentCustomer.OwnerName + Environment.NewLine);// owner name
            vehicleInfo.Append("Status: " + currentCustomer.Status + Environment.NewLine);// status 
            for(int i = 0; i < vehicle.Wheels.Count; i++)
            {
                vehicleInfo.AppendFormat("Wheel #{0} -     " + Environment.NewLine, i);
                vehicleInfo.Append("Manufacturer name: " + vehicle.Wheels[i].ManufacturerName);
                vehicleInfo.Append(Environment.NewLine + "    Current air pressure: " + vehicle.Wheels[i].CurrentAirPressure);
                vehicleInfo.Append(Environment.NewLine + "    Max air pressure: " + vehicle.Wheels[i].MaxAirPressure);
                vehicleInfo.Append(Environment.NewLine);
            }

            if(currentCustomer.Vehicle.Battery != null){
                vehicleInfo.AppendFormat("Time left: {0} hours " + Environment.NewLine, vehicle.Battery.TimeLeft);
                vehicleInfo.AppendFormat("Time capacity: {0} hours " + Environment.NewLine, vehicle.Battery.TimeCapacity);
            }
            else
            {
                vehicleInfo.Append("Gas type: "+ Environment.NewLine + vehicle.GasTank.GasType);
                vehicleInfo.AppendFormat("Gas amount: {0} liters" + Environment.NewLine,  vehicle.GasTank.CurrentAmount);
                vehicleInfo.AppendFormat("Gas capacity: {0} liters" + Environment.NewLine, vehicle.GasTank.MaxCapacity);
            }

            for (int i = 0; i < vehicle.ExtraTypeData.Count; i++)
            {
                vehicleInfo.AppendLine(vehicle.ExtraTypeData.ElementAt(i).Key + ": " + vehicle.ExtraTypeData.ElementAt(i).Value);
                vehicleInfo.Append(Environment.NewLine);
            }

            Console.WriteLine(vehicleInfo);

            Console.WriteLine("Press anything to get back to main screen");
            Console.ReadLine();
            GarageFunctions();
        }
    }
    
}