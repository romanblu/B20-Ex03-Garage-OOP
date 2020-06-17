using Ex03.GarageLogic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
   public class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            GarageUI ui = new GarageUI(garage);
            ui.GarageFunctions();

           /* CreateNewVehicle factory = new CreateNewVehicle();
            

            Garage garage = new Garage();
            
            factory.VehicleInProduction(eVehicleType.Car, "tesla", "asd123", 0.5f);
            List<string> extraData = new List<string>();
            extraData.Add("Black"); extraData.Add("2");
            Vehicle c1 = factory.FinishProduction(extraData);

            factory.VehicleInProduction(eVehicleType.Car, "tesla", "123456", 0.5f);
            extraData = new List<string>();
            extraData.Add("White"); extraData.Add("4");
            Vehicle c2 = factory.FinishProduction(extraData);

            factory.VehicleInProduction(eVehicleType.Car, "tesla", "qwerty", 0.5f);
            extraData = new List<string>();
            extraData.Add("Silver"); extraData.Add("2");
            Vehicle c3 = factory.FinishProduction(extraData);
            garage.InsertVehicle(c1, "faggito", "123123");
            garage.InsertVehicle(c2, "faggito1", "123123");
            garage.InsertVehicle(c3, "faggito2", "123123");
            GarageUI ui = new GarageUI(garage);
            Console.WriteLine("THERE ARE {0} VEHICLES", garage.customersList.Count);
            //ui.GarageFunctions();

            Console.WriteLine("GAS AMOUNT " + c2.GasTank.CurrentAmount);

            Console.ReadLine();
        */}
    }
}
