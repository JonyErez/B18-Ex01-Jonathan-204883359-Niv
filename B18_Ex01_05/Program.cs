using System;

namespace B18_Ex01_05
{
	class Program
	{
		public static void Main()
		{
			int userInput = readInput();
			printNumberData(userInput);
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		private static int readInput()
		{
			int userInput = 0;
			string initialInput;
			bool isValid = false;

			Console.WriteLine("Please enter a 6 digit long number: ");
			initialInput = Console.ReadLine();
			while (!isValid)
			{
				isValid = initialInput.Length == 6;
				if (isValid)
				{
					isValid = int.TryParse(initialInput, out userInput) && userInput > 0;
				}

				if (!isValid)
				{
					Console.WriteLine("Invalid input!");
					Console.WriteLine("Please enter a valid 6 digit long number: ");
					initialInput = Console.ReadLine();
				}
			}

			return userInput;
		}

		private static void findMinAndMaxDigits(int i_Number, out int io_MinDigit, out int io_MaxDigit)
		{
			int currentDigit;
			io_MaxDigit = io_MinDigit = i_Number % 10;
			i_Number /= 10;
			while (i_Number != 0)
			{
				i_Number = Math.DivRem(i_Number, 10, out currentDigit);
				if (currentDigit < io_MinDigit)
				{
					io_MinDigit = currentDigit;
				}
				if (currentDigit > io_MaxDigit)
				{
					io_MaxDigit = currentDigit;
				}
			}
		}

		private static int howManyEvenDigits (int i_Number)
		{
			int evenDigits = 0;
			int currentDigit;

			while (i_Number != 0)
			{
				i_Number = Math.DivRem(i_Number, 10, out currentDigit);
				if (currentDigit % 2 == 0)
				{
					evenDigits++;
				}
			}

			return evenDigits;
		}

		private static int howManyDigitsSmallerThanSingles(int i_Number)
		{
			int smallerThanSinglesDigit = 0;
			int currentDigit;
			int singlesDigit;

			i_Number = Math.DivRem(i_Number, 10, out singlesDigit);
			while (i_Number != 0)
			{
				i_Number = Math.DivRem(i_Number, 10, out currentDigit);
				if (currentDigit < singlesDigit)
				{
					smallerThanSinglesDigit++;
				}
			}

			return smallerThanSinglesDigit;
		}

		private static void printNumberData(int i_Number)
		{
			int maxDigit, minDigit, evenDigits, smallerThanSinglesDigit;

			findMinAndMaxDigits(i_Number, out minDigit, out maxDigit);
			evenDigits = howManyEvenDigits(i_Number);
			smallerThanSinglesDigit = howManyDigitsSmallerThanSingles(i_Number);
			Console.WriteLine("The smallest digit in the number is: {0}.", minDigit);
			Console.WriteLine("The biggest digit in the number is: {0}.", maxDigit);
			Console.WriteLine("The number of even digits in the number is: {0}.", evenDigits);
			Console.WriteLine("There number of digits smaller than the singles digit is: {0}.", smallerThanSinglesDigit);


		}
	}
}
