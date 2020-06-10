using System;
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

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, string i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
            base.Battery = new Battery(1.2f);
            base.GasVehicle = false;
            this.licenseType = (License)Enum.Parse(typeof(License), i_LicenseType);
            this.engineVolume = i_EngineVolume;

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
