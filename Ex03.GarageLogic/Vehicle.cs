using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string modelName;// The specific model name of the vehicle
        private string licensePlate;// The specific license plate of the vehicle
        private float energyLeft;// The amount of energy left in the vehicle
        private List<Wheel> wheels;
        
        public List<Wheel> Wheels { get { return this.wheels; }  }

        public string Model { get { return this.modelName; } set { this.modelName = value; } }//The method returns and sets the value of modelName
        public string LicensePlate { get { return licensePlate; } set { licensePlate = value; } }// The method returns and sets the value of licencePlate

        public Vehicle(string I_ModelName, string i_LicenseNumber, float i_EnergyLeft)
        {
            this.modelName = I_ModelName;
            this.licensePlate = i_LicenseNumber;
            this.energyLeft = i_EnergyLeft;
            
        }
    }
}
