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
            GarageUI ui = new GarageUI();
            //  ui.GarageFunctions();
            Garage garage = new Garage();

            CreateNewVehicle c = new CreateNewVehicle();
            c.VehicleInProduction(eVehicleType.Car, "asd", "123", 0.5f);

            Vehicle car = c.FinishProduction(new List<string> { "Black", "3" });


            CreateNewVehicle c2 = new CreateNewVehicle();
            c2.VehicleInProduction(eVehicleType.Car, "asda", "1234", 0.5f);

            Vehicle car2 = c.FinishProduction(new List<string> { "Black", "4" });

            garage.InsertVehicle(car, "ASGAG", "12312312");
            garage.InsertVehicle(car2, "ASGAG", "12312312");
            Console.WriteLine(garage.customersList.Count);
            try
            {
                car2.Wheels[0].Inflate(100);
            }catch(ValueOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            eColor color = new eColor();
            try
            {
                if (!Enum.TryParse("2", out color))
                {
                    Console.WriteLine("Failed");
                    throw new FormatException("Color can contain only the following values: " + ui.ListEnumOptions(color));
                }
            }catch( FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Failed");
            }
            Console.WriteLine(color.ToString());
            Console.ReadLine();
        }
    }
}
