﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
    {
        private string modelName; // The specific model name of the vehicle
        private string licenseNumber; // The specific license plate of the vehicle
        private float energyLeft; // The amount of energy left in the vehicle
        private List<Wheel> wheels = new List<Wheel>(); // A list of the wheels of the specific vehicle
        private bool gasVehicle; // Does the vehicle have a gas tank or not?
        private GasTank gasTank;
        private Battery battery;
        private Dictionary<string, string> extraTypeData = new Dictionary<string, string>();

        public Dictionary<string, string> ExtraTypeData { get { return extraTypeData; } set { extraTypeData = value; } }
        public GasTank GasTank { get { return gasTank; } set { gasTank = value; } }
        public Battery Battery { get { return battery; } set { battery = value; } }
        public bool GasVehicle { get { return gasVehicle; } set { gasVehicle = value; } }
        public float EnergyLeft { get { return energyLeft; } set { energyLeft = value; } }
        public List<Wheel> Wheels { get { return this.wheels; } }
        public string Model { get { return this.modelName; } set { this.modelName = value; } } // The method returns and sets the value of modelName
        public string LicenseNumber { get { return licenseNumber; } set { licenseNumber = value; } } // The method returns and sets the value of licencePlate

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft)
        {
            this.modelName = i_ModelName;
            this.licenseNumber = i_LicenseNumber;
            this.energyLeft = i_EnergyLeft;
            
        }
    }
}
