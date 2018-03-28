using System;
using System.Collections.Generic;
using System.Text;

namespace B18_Ex01_03
{
	class Program
	{
		public static void Main()
		{
			int hourglassHeight;

			hourglassHeight = readInput();
			Console.WriteLine("{0}{1}",System.Environment.NewLine, B18_Ex01_02.Program.Hourglass(hourglassHeight));
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		private static int readInput()
		{
			string sizeOfHourglass;
			int hourglassHeight;

			Console.WriteLine("Please enter the size of the hourglass: ");
			sizeOfHourglass = Console.ReadLine();
			while (!checkInputValidity(sizeOfHourglass, out hourglassHeight))
			{
				Console.WriteLine("Please enter a valid size for the hourglass (positive int): ");
				sizeOfHourglass = Console.ReadLine();
			}

			return hourglassHeight;
		}

		private static bool checkInputValidity(string i_SizeOfHourGlass, out int o_HourglassHeight)
		{
			bool isValidInput = int.TryParse(i_SizeOfHourGlass, out o_HourglassHeight);
			isValidInput = isValidInput && o_HourglassHeight > 0;
			
			return isValidInput;
		}
	}
}
