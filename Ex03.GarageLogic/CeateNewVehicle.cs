using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class CreateNewVehicle
    {
        
        string modelName;
        string licenseNumber;
        float energyLeft;
        eVehicleType vehicleType;

        public void VehicleInProduction(eVehicleType i_VehicleType, string i_ModelName, string i_LicenseNumber, float i_EnergyLeft)
        {
            // we first start the vehicle production, then by the type of the car we will update the next data then create the vehicle 
            vehicleType = i_VehicleType;
            modelName = i_ModelName;
            licenseNumber = i_LicenseNumber;
            energyLeft = i_EnergyLeft;
        }

        List<string> extraData = new List<string>();

        public List<string> GetExtraData(eVehicleType i_VehicleType)
        {
            switch(i_VehicleType){
                case eVehicleType.Car:
                    extraData.Add("Color");
                    extraData.Add("Number Of Doors");
                    break;
                case eVehicleType.ElectricCar:
                    extraData.Add("Color");
                    extraData.Add("Number Of Doors");
                    break;
                case eVehicleType.Motorcycle:
                    extraData.Add("License Type");
                    extraData.Add("Motor Volume");
                    break;
                case eVehicleType.ElectricMotorcycle:
                    extraData.Add("License Type");
                    extraData.Add("Motor Volume");
                    break;
                case eVehicleType.Truck:
                    extraData.Add("Dangerous Substances True\\False");
                    extraData.Add("Trunk Volume");
                    break;
                default:
                    throw new ArgumentException();
                    

            }
            return extraData;
        }

        public Vehicle FinishProduction(List<string> i_ExtraData)
        {
            Vehicle readyVehicle = null;
            switch (this.vehicleType)
            {
                case eVehicleType.Car:
                    eDoorsAmount numberOfDoors;
                    if(!Enum.TryParse(i_ExtraData[1], out numberOfDoors))
                    {
                        throw new FormatException("Doors amount can only contain the following values: " + ListEnumOptions(numberOfDoors));
                    }
                    eColor color;
                    if(!Enum.TryParse(i_ExtraData[0], out color))
                    {
                        throw new FormatException("Color can contain only the following values: " + ListEnumOptions(color));
                    }
                    readyVehicle = new Car(this.modelName, this.licenseNumber, this.energyLeft, color.ToString(), (int)numberOfDoors);
                    break;

                case eVehicleType.ElectricCar:
                    if (!Enum.TryParse(i_ExtraData[1], out numberOfDoors))
                    {
                        throw new FormatException("Doors amount can only contain the following values: " + ListEnumOptions(numberOfDoors));
                    }
                    
                    if (!Enum.TryParse(i_ExtraData[0], out color))
                    {
                        throw new FormatException("Color can contain only the following values: " + ListEnumOptions(color));
                    }
                    readyVehicle = new ElectricCar(this.modelName, this.licenseNumber, this.energyLeft, i_ExtraData[0], int.Parse(i_ExtraData[1]));
                    break;
                case eVehicleType.Motorcycle:
                    eLicense licenseType;
                    if (!Enum.TryParse(i_ExtraData[0], out licenseType))
                    {
                        throw new FormatException("License type can only contain the following values: " + ListEnumOptions(licenseType));
                    }
                    int engineVolume;
                    if (!int.TryParse(i_ExtraData[1], out engineVolume))
                    {
                        throw new FormatException("Bad value for engine volume. Enter integer value" );
                    }
                    readyVehicle = new Motorcycle(this.modelName, this.licenseNumber, this.energyLeft, i_ExtraData[0], engineVolume);
                    break;

                case eVehicleType.ElectricMotorcycle:
                   
                    if (!Enum.TryParse(i_ExtraData[0], out licenseType))
                    {
                        throw new FormatException("License type can only contain the following values: " + ListEnumOptions(licenseType));
                    }
                   
                    if (!int.TryParse(i_ExtraData[1], out engineVolume))
                    {
                        throw new FormatException("Bad value for engine volume. Enter integer value");
                    }
                    readyVehicle = new ElectricMotorcycle(this.modelName, this.licenseNumber, this.energyLeft, i_ExtraData[0], engineVolume);
                    break;
                case eVehicleType.Truck:
                    bool dangerousSubstances;
                    if (!bool.TryParse(i_ExtraData[0], out dangerousSubstances))
                    {
                        throw new FormatException("Can only accept true or false for dangerous substances");
                    }
                    float trunkVolume;
                    if (!float.TryParse(i_ExtraData[1], out trunkVolume))
                    {
                        throw new FormatException("Bad value for trunk volume. Enter float number");
                    }
                    readyVehicle = new Truck(this.modelName, this.licenseNumber, this.energyLeft, dangerousSubstances, trunkVolume);
                    break;
                    
            }
            return readyVehicle;
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

    }

}
