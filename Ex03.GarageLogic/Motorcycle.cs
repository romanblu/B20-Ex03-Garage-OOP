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

        public License LicenseType{ get { return this.licenseType; } set { this.licenseType = value; }  }
        public int EngineVolume { get { return this.engineVolume; } set { this.engineVolume = value; } }

        public Motorcycle(string model, string licenseNumber, float energyLeft, List<Wheel> wheels, License licenseType, int engineVolume)
            :base(model,licenseNumber,energyLeft,wheels)
        {
            this.licenseType = licenseType;
            this.engineVolume = engineVolume;

            for (int i = 0; i < 2; i++)
            {
                wheels.Add(new Wheel(30));
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
