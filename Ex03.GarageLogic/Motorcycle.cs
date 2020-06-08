using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private License licenseType;
        private int engineVolume;
        private GasTank gasTank = new GasTank(GasTank.Gas.Octan95, 7);
        //private List<Wheel> wheels = new List<Wheel>();

        public License LicenseType{ get { return this.licenseType; } set { this.licenseType = value; }  }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyLeft, string i_LicenseType, int i_EngineVolume)
            :base(i_ModelName, i_LicenseNumber, i_EnergyLeft)
        {
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
