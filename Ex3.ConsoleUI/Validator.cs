using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.ConsoleUI
{
    class Validator
    {
        

        public float ValidateEnergyLeft(string i_InputToCheck)
        {
            float energyLeft;
            while (!float.TryParse(i_InputToCheck, out energyLeft) && (energyLeft < 0 || energyLeft > 1))
            {
                Console.WriteLine("Please enter a valid value between 0 and 1");
                i_InputToCheck = Console.ReadLine();
            }
            return energyLeft;
        }

        public TEnum ValidateEnumType<TEnum>(string i_InputToCheck) where TEnum : struct
        {
            TEnum parsedEnum;
            while (!Enum.TryParse<TEnum>(i_InputToCheck, out parsedEnum))// formatexcecption
            {
                StringBuilder enumListing = new StringBuilder();

                for (int i = 0; i < Enum.GetNames(parsedEnum.GetType()).Length; i++)
                {
                    enumListing.Append(Enum.GetNames(parsedEnum.GetType())[i]);
                    if (i != Enum.GetNames(parsedEnum.GetType()).Length - 1)
                    {
                        enumListing.Append(", ");
                    }
                }

                Console.WriteLine("Wrong value please choose from the options: " + enumListing.ToString());
                i_InputToCheck = Console.ReadLine();
            }
            return parsedEnum;
        }

    }
}
