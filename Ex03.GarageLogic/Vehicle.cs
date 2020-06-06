using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string model;
        private string licenseNumber;
        private float energyLeft;
        private List<Wheel> wheels;
        
        public string Model { get { return this.model; } set { this.model = value; } }

        public Vehicle(string model, string licenseNumber, float energyLeft, List<Wheel> wheels)
        {
            this.model = model;
            this.licenseNumber = licenseNumber;
            this.energyLeft = energyLeft;
            this.wheels = wheels;
        }
    }
}
