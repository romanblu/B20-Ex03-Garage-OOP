using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
    class GarageUI
    {
        private eFunctions function;
        private List<Object> newVehicle;

        public GarageUI(List<Object> i_NewVehicle)
        {
            newVehicle = i_NewVehicle;// gets a list of vehicles
        }


        //TODO - add a new vehicle with all the new information from the userscreen
        //     - do the functions the user wants acording to his choise.

        public enum eFunctions
        {
            changeVehicleStatus = 1,
            InflateWheels = 2,
            Refuel = 3,
            Recharged = 4,
            FullData = 5
        }
    }
}
