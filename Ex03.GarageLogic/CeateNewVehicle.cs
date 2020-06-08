using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class CeateNewVehicle
    {
        private eVehicleType vehicle;

        public static Vehicle CreateVehicle(string i_ModelName, string i_LicensePlate, float i_EnergyLeft, List<Wheel> i_Wheels,
            string i_VehicleType, List<string> i_VehicleExtra)
        {
            Vehicle newVehicle = null;
            if (i_VehicleType == "Car")
            {
                newVehicle = new Car(i_ModelName, i_LicensePlate, i_EnergyLeft);
            }
            else if (i_VehicleType == "Electric Car")
            {
                newVehicle = new ElectricCar();
            }
            else if (i_VehicleType == "Motorcycle")
            {
                newVehicle = new Motorcycle();
            }
            else if (i_VehicleType == "Electric Motorcycle")
            {
                newVehicle = new ElectricMotorcycle();
            }
            else if (i_VehicleType == "Truck")
            {
                newVehicle = new Truck();
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
    }
}
