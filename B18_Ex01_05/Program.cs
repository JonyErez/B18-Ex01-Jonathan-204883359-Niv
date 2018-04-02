using System;

namespace B18_Ex01_05
{
	public class Program
	{
		public	static	void	Main()
		{
			uint userInput;
			
			userInput = readInput();
			printNumberData(userInput);
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		private static	uint	readInput()
		{
			uint	userInput;
			string	initialInput;

			Console.WriteLine("Please enter a 6 digit long number: ");
			initialInput = Console.ReadLine();
			while (initialInput.Length != 6 || !uint.TryParse(initialInput, out userInput))
			{
				Console.WriteLine("Invalid input!");
				Console.WriteLine("Please enter a valid 6 digit long number: ");
				initialInput = Console.ReadLine();
			}

			return userInput;
		}

		private static	ushort	findMinOrMaxDigit(uint i_Number, bool findMax)
		{
			ushort currentDigit;
			ushort numberBase = 10;
			ushort resDigit;

			resDigit = (ushort)(i_Number % numberBase);
			i_Number /= numberBase;
			while (i_Number != 0)
			{
				currentDigit = (ushort)(i_Number % numberBase);
				i_Number = i_Number / numberBase;
				if (findMax)
				{
					resDigit = Math.Max(currentDigit, resDigit);
				}
				else
				{
					resDigit = Math.Min(currentDigit, resDigit);
				}
			}

			return resDigit;
		}

		private static	ushort	howManyEvenDigits(uint i_Number)
		{
			ushort evenDigits = 0;
			ushort currentDigit;
			uint numberBase = 10;

			while (i_Number != 0)
			{
				currentDigit = (ushort)(i_Number % numberBase);
				i_Number = i_Number / numberBase;
				if (currentDigit % 2 == 0)
				{
					evenDigits++;
				}
			}

			return evenDigits;
		}

		private static	ushort	howManyDigitsSmallerThanSingles(uint i_Number)
		{
			ushort smallerThanSinglesDigit = 0;
			ushort currentDigit;
			ushort singlesDigit;
			ushort numberBase = 10;

			singlesDigit = (ushort)(i_Number % numberBase);
			i_Number = i_Number / numberBase;
			while (i_Number != 0)
			{
				currentDigit = (ushort)(i_Number % numberBase);
				i_Number = i_Number / numberBase;
				if (currentDigit < singlesDigit)
				{
					smallerThanSinglesDigit++;
				}
			}

			return smallerThanSinglesDigit;
		}

		private static	void	printNumberData(uint i_Number)
		{
			ushort		maxDigit;
			ushort		minDigit;
			ushort		evenDigits;
			ushort		smallerThanSinglesDigit;
			const bool	v_FindMax = true;

			maxDigit = findMinOrMaxDigit(i_Number, v_FindMax);
			minDigit = findMinOrMaxDigit(i_Number, !v_FindMax);
			evenDigits = howManyEvenDigits(i_Number);
			smallerThanSinglesDigit = howManyDigitsSmallerThanSingles(i_Number);
			string numberData = string.Format(
@"{4}The smallest digit in the number is: {0}.
The biggest digit in the number is: {1}.
The number of even digits in the number is: {2}.
There number of digits smaller than the singles digit is: {3}.{4}{4}",
minDigit,
maxDigit,
evenDigits,
smallerThanSinglesDigit,
System.Environment.NewLine);
			Console.Write(numberData);
		}
	}
}
