using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool dangerousSubstances; // Does the truck carry Hazardous Materials?yes/no
        private float trunkCapacity; // The engine capacity of the truck
        public bool DangerousSubstances { get { return this.dangerousSubstances; } set { this.dangerousSubstances = value; } }
        public float TrunkCapacity { get { return this.trunkCapacity; } set { this.trunkCapacity = value; } }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, bool i_DangerousSubstances, float i_TrunkCapacity)
        : base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
            GasVehicle = true;
            this.dangerousSubstances = i_DangerousSubstances;
            this.trunkCapacity = i_TrunkCapacity;
            GasTank = new GasTank(eGasType.Soler, 120);
            GasTank.CurrentAmount = EnergyLeft * GasTank.MaxCapacity;
            for (int i = 0; i < 16; i++)
            {
                Wheels.Add(new Wheel(28));
            }

        }

    }
}
