using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class CreateNewVehicle
    {
        private eVehicleType vehicle;
        
        public Vehicle CreateVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLeft,
            string i_VehicleType, List<string> i_VehicleExtraData)
        {
            Vehicle newVehicle = null;
            if (i_VehicleType == "Car")
            {
                newVehicle = new Car(i_ModelName, i_LicensePlate, i_EnergyLeft,  i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Electric Car")
            {
                newVehicle = new ElectricCar(i_ModelName, i_LicensePlate, i_EnergyLeft,  i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Motorcycle")
            {
                newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, i_EnergyLeft, i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Electric Motorcycle")
            {
                newVehicle = new ElectricMotorcycle(i_ModelName, i_LicensePlate, i_EnergyLeft, i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Truck")
            {
                newVehicle = new Truck(i_ModelName, i_LicensePlate, i_EnergyLeft,bool.Parse( i_VehicleExtraData[0]), float.Parse(i_VehicleExtraData[1]));
            }
            else
            {
                throw (new ArgumentException("Your Vehicle is not valid"));
            }

            return newVehicle;

        }
        
        public enum eVehicleType
        {
            Car,
            ElectricCar,
            Motorcycle,
            ElectricMotorcycle,
            Truck

        }
        
        /*
        public Car CreateCar(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
        {
            return new Car( i_ModelName, i_LicensePlate, i_EnergyLeft, i_CarColor,i_AmountOfDoors);
        }
        public ElectricCar CreateElectricCar(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, string i_CarColor, int i_AmountOfDoors)
        {
            return new ElectricCar(i_ModelName, i_LicensePlate, i_EnergyLeft, i_CarColor, i_AmountOfDoors);
        }

        public Motorcycle CreateMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, string i_LicenseType, int i_EngineVolume)
        {
            return new Motorcycle(i_ModelName, i_LicenseNumber, i_EnergyLeft, i_LicenseType, i_EngineVolume);
        }

        public ElectricMotorcycle CreateElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, string i_LicenseType, int i_EngineVolume)
        {
            return new ElectricMotorcycle(i_ModelName, i_LicenseNumber, i_EnergyLeft, i_LicenseType, i_EngineVolume);
        }
        public Truck CreateTruck(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, bool i_DangerousSubstances, int i_TrunkCapacity)
        {
            return new Truck(i_ModelName, i_LicenseNumber, i_EnergyLeft, i_DangerousSubstances, i_TrunkCapacity);
        }

        */
    }
}
