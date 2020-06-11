using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex3.ConsoleUI
{
    class GarageUI
    {
        // this class should activate all the functions on the vehicle
        private eFunctions function;
        private List<string> currentVehicleData;


        public GarageUI(List<string> i_CurrentVehicle)
        {
            currentVehicleData = i_CurrentVehicle;// gets a new of vehicles
        }



        //TODO - add a new vehicle with all the new information from the userscreen
        //     - do the functions the user wants acording to his choise.

        public enum eFunctions
        {
            changeVehicleStatus = 1,
            InflateTires = 2,
            Refuel = 3,
            Recharged = 4,
            //FullData = 5
        }
    }
}
