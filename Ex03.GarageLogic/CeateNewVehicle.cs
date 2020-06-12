using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        private eVehicleType vehicle;
        
        //אם עשינו כבר שינוי לסטרינג במחלקות של רכב אופנוע וכו אז אין צורך שהרשימה  vehicleextradata  תיהיה מסוג object
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
        
        
    }
}
