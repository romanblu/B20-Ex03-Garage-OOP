using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Vehicle
    {
        private eLicense licenseType; // The specific type of the licence 
        private int engineVolume; // The engine capacity of the motorcycle

        public eLicense LicenseType { get { return this.licenseType; } set { this.licenseType = value; } }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public ElectricMotorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, eLicense i_LicenseType, int i_EngineVolume)
            : base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
            Battery = new Battery(1.2f);
            GasVehicle = false;
            this.licenseType = i_LicenseType;
            this.engineVolume = i_EngineVolume;
            Battery.TimeLeft = EnergyLeft * Battery.TimeCapacity;
            for (int i = 0; i < 2; i++)
            {
                Wheels.Add(new Wheel(30));
            }
        }


    }
}
