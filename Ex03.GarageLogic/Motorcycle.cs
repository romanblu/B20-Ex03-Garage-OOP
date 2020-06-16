using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLicense licenseType;// The specific type of the licence 
        private int engineVolume;//The engine capacity of the motorcycle

        public eLicense LicenseType{ get { return this.licenseType; } set { this.licenseType = value; }  }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, eLicense i_LicenseType, int i_EngineVolume)
            :base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
            //this.licenseType = (License)Enum.Parse(typeof(License), i_LicenseType);// formatexcecption
            this.licenseType = i_LicenseType;
            this.engineVolume = i_EngineVolume;
            base.GasVehicle = true;
            base.GasTank = new GasTank(eGasType.Octan95, 7);
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
