﻿using System;
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
        public bool DangerousSubstances { get { return this.dangerousSubstances} set { this.dangerousSubstances = value; } }
        public int TrunkCapacity { get { return this.trunkCapacity; } set { this.trunkCapacity = value; } }

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, bool i_DangerousSubstances, int i_TrunkCapacity)
        : base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
            base.GasVehicle = true;
            this.dangerousSubstances = i_DangerousSubstances;
            this.trunkCapacity = i_TrunkCapacity;
            base.GasTank = new GasTank(GasTank.Gas.Soler, 120);

            for(int i = 0; i < 16; i++)
            {
                base.Wheels.Add(new Wheel(28));
            }

        }

    }
}
