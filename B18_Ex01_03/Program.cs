using System;
using System.Text;

namespace B18_Ex01_03
{
	public class Program
	{
		public	static	void	Main()
		{
			uint hourglassHeight;

			hourglassHeight = readInput();
			Console.WriteLine("{0}{1}", System.Environment.NewLine, B18_Ex01_02.Program.Hourglass(hourglassHeight));
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		private static	uint	readInput()
		{
			string sizeOfHourglass;
			uint hourglassHeight;

			Console.WriteLine("Please enter the size of the hourglass: ");
			sizeOfHourglass = Console.ReadLine();
			while (!uint.TryParse(sizeOfHourglass, out hourglassHeight))
			{
				Console.WriteLine("Invalid input!");
				Console.WriteLine("Please enter a valid size for the hourglass (positive int): ");
				sizeOfHourglass = Console.ReadLine();
			}

			return hourglassHeight;
		}
	}
}
