using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool dangerousSubstances;
        private int trunkCapacity;
        private GasTank gasTank = new GasTank(GasTank.Gas.Soler, 120);

        public bool DangerousSubstances { get { return this.dangerousSubstances} set { this.dangerousSubstances = value; } }
        public int TrunkCapacity { get { return this.trunkCapacity; } set { this.trunkCapacity = value; } }

        public Truck(string model, string licenseNumber, float energyLeft, List<Wheel> wheels, bool dangerousSubstances, int trunkCapacity)
        : base(model, licenseNumber, energyLeft, wheels)
        {
            this.dangerousSubstances = dangerousSubstances;
            this.trunkCapacity = trunkCapacity;

            for(int i = 0; i < 16; i++)
            {
                wheels.Add(new Wheel(28));
            }
        }

    }
}
