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
        private Battery battery = new Battery(1.2f);
        private List<Wheel> wheels = new List<Wheel>();

        public License LicenseType { get { return this.licenseType; } set { this.licenseType = value; } }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public ElectricMotorcycle(string model, string licenseNumber, float energyLeft, License licenseType, int engineVolume)
            : base(model, licenseNumber, energyLeft )
        {
            this.licenseType = licenseType;
            this.engineVolume = engineVolume;
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
