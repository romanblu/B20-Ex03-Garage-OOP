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
        string modelName;
        string licenseNumber;
        float energyLeft;
        string vehicleType;

        public void VehicleInProduction(string i_VehicleType, string i_ModelName, string i_LicenseNumber, float i_EnergyLeft)
        {
            // we first start the vehicle production, then by the type of the car we will update the next data then create the vehicle 
            vehicleType = i_VehicleType;
            modelName = i_ModelName;
            licenseNumber = i_LicenseNumber;
            energyLeft = i_EnergyLeft;
        }

        List<string> extraData = new List<string>();

        public List<string> GetExtraData(string i_VehicleType)
        {
            switch(i_VehicleType){
                case "Car":
                    extraData.Add("Color");
                    extraData.Add("Number Of Doors");
                    break;
                case "ElectricCar":
                    extraData.Add("Color");
                    extraData.Add("Number Of Doors");
                    break;
                case "Motorcycle":
                    extraData.Add("License Type");
                    extraData.Add("Motor Volume");
                    break;
                case "ElectricMotorcycle":
                    extraData.Add("License Type");
                    extraData.Add("Motor Volume");
                    break;
                case "Truck":
                    extraData.Add("Dangerous Substances True\\False");
                    extraData.Add("Trunk Volume");
                    break;
                default:
                    // Wrong type exception
                    break;

            }
            return extraData;
        }

        public Vehicle FinishProduction(List<string> i_ExtraData)
        {
            Vehicle readyVehicle;
            switch (this.vehicleType)
            {
                case "Car":
                    readyVehicle = new Car(this.modelName, this.licenseNumber, this.energyLeft, extraData[0], int.Parse(extraData[1]));
                    break;
                case "ElectricCar":
                    readyVehicle = new ElectricCar(this.modelName, this.licenseNumber, this.energyLeft, extraData[0], int.Parse(extraData[1]));
                    break;
                case "Motorcycle":
                    readyVehicle = new Motorcycle(this.modelName, this.licenseNumber, this.energyLeft, extraData[0], int.Parse(extraData[1]));
                    break;
                case "ElectricMotorcycle":
                    readyVehicle = new ElectricMotorcycle(this.modelName, this.licenseNumber, this.energyLeft, extraData[0], int.Parse(extraData[1]));
                    break;
                case "Truck":
                    readyVehicle = new Truck(this.modelName, this.licenseNumber, this.energyLeft, bool.Parse(extraData[0]), int.Parse(extraData[1]));
                    break;
                default:
                    // Wrong type exception
                    throw new Exception();
                    break;

            }
            return readyVehicle;
        }

        /*
        public Vehicle CreateVehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft,
            string i_VehicleType, List<string> i_VehicleExtraData)
        {
            Vehicle newVehicle = null;

            if (i_VehicleType == "Car")
            {
                newVehicle = new Car(i_ModelName, i_LicenseNumber, i_EnergyLeft,  i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Electric Car")
            {
                newVehicle = new ElectricCar(i_ModelName, i_LicenseNumber, i_EnergyLeft,  i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Motorcycle")
            {
                newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, i_EnergyLeft, i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Electric Motorcycle")
            {
                newVehicle = new ElectricMotorcycle(i_ModelName, i_LicenseNumber, i_EnergyLeft, i_VehicleExtraData[0], int.Parse(i_VehicleExtraData[1]));
            }
            else if (i_VehicleType == "Truck")
            {
                newVehicle = new Truck(i_ModelName, i_LicenseNumber, i_EnergyLeft,bool.Parse( i_VehicleExtraData[0]), float.Parse(i_VehicleExtraData[1]));
            }
            else
            {
                throw (new ArgumentException("Your Vehicle is not valid"));
            }

            return newVehicle;

        }
        */
        
    }
}
