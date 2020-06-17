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
            ui.GarageFunctions();
            
            
           // eColor color = new eColor();
           // try
           // {
            //    if (!Enum.TryParse("2", out color))
            //    {
             //       Console.WriteLine("Failed");
              //      throw new FormatException("Color can contain only the following values: " + ui.ListEnumOptions(color));
             //   }
           // }catch( FormatException e)
           // {
            ////    Console.WriteLine(e.Message);
            //    Console.WriteLine("Failed");
           // }
          //  Console.WriteLine(color.ToString());
          //  Console.ReadLine();
        }
    }
}
