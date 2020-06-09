﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Vehicle
    {
        private License licenseType;
        private int engineVolume;

        public License LicenseType { get { return this.licenseType; } set { this.licenseType = value; } }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public ElectricMotorcycle(string model, string licenseNumber, float energyLeft, string licenseType, int engineVolume)
            : base(model, licenseNumber, energyLeft )
        {
            base.Battery = new Battery(1.2f);
            base.GasVehicle = false;
            this.licenseType = (License)Enum.Parse(typeof(License), licenseType);
            this.engineVolume = engineVolume;

            for (int i = 0; i < 2; i++)
            {
                base.Wheels.Add(new Wheel(30));
            }
        }

        public enum License
        {
            A,
            A1,
            AA,
            B
        }

    }
}
