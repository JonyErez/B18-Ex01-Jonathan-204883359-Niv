using System;

namespace B18_Ex01_01
{
	public static class Program
	{
		public enum eBase
		{
			Two = 2,
			Ten = 10
		}

		public const int k_NumberOfInputs = 3;
		public const int k_ExpectedBinaryNumberLength = 9;

		public static float s_AvgNumOfZeros;
		public static float s_AvgNumOfOnes;
		public static int s_PowerOfTwoCounter;
		public static int s_IsDownwardSeries;
		public static float s_AvgSumOfNumbers;

		public static void Main()
		{
			BinaryAnalyzer();
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public static void BinaryAnalyzer()
		{
			int[] decimalNumbers = new int[k_NumberOfInputs];
			for (int i = 0; i < k_NumberOfInputs; i++)
			{
				Console.WriteLine("Please enter a binary number (9 digits long): ");
				decimalNumbers[i] = handleBinaryNumber();
			}

			s_AvgSumOfNumbers /= (float)k_NumberOfInputs;
			s_AvgNumOfOnes /= (float)k_NumberOfInputs;
			s_AvgNumOfZeros /= (float)k_NumberOfInputs;
			printStatistics(decimalNumbers);
		}

		private static int handleBinaryNumber()
		{
			string binaryNumber = readBinary();
			countOnesAndZeroes(binaryNumber);
			isAPowerOfTwo(binaryNumber);
			int decimalNumber = binaryToInt(binaryNumber);
			isDownwardSeries(decimalNumber);
			s_AvgSumOfNumbers += decimalNumber;
			return decimalNumber;
		}

		private static string readBinary()
		{
			string binaryNumber = Console.ReadLine();
			while (!isLegalBinaryNumber(binaryNumber))
			{
				Console.WriteLine("Invalid input!");
				Console.WriteLine("Please enter a valid binary number (9 bits long):");
				binaryNumber = Console.ReadLine();
			}

			return binaryNumber;
		}

		private static bool isLegalBinaryNumber(string i_BinaryNumber)
		{
			////Regex can be used instead:
			////.Text.RegularExpressions.Regex isBinary = new System.Text.RegularExpressions.Regex(@"^[01]{9}$");
			////return isBinary.IsMatch(i_BinaryNumber);

			bool isBinary = i_BinaryNumber.Length == k_ExpectedBinaryNumberLength;
			if (isBinary)
			{
				for (int currentDigit = 0; isBinary && currentDigit < i_BinaryNumber.Length; currentDigit++)
				{
					isBinary = i_BinaryNumber[currentDigit] == '0' || i_BinaryNumber[currentDigit] == '1';
				}
			}

			return isBinary;
		}

		private static void countOnesAndZeroes(string i_BinaryNumber)
		{
			foreach (char currentDigit in i_BinaryNumber)
			{
				if (currentDigit == '1')
				{
					s_AvgNumOfOnes++;
				}
				else
				{
					s_AvgNumOfZeros++;
				}
			}
		}

		private static void isAPowerOfTwo(string i_BinaryNumber)
		{
			int howManyOnes = 0;
			foreach (char currentDigit in i_BinaryNumber)
			{
				if (currentDigit == '1')
				{
					howManyOnes++;
				}
			}

			if (howManyOnes == 1)
			{
				s_PowerOfTwoCounter++;
			}
		}

		private static int binaryToInt(string i_BinaryNumber)
		{
			int digitWeight = 1;
			int decimalNumber = 0;
			for (int currentDigit = i_BinaryNumber.Length - 1; currentDigit >= 0; currentDigit--)
			{
				decimalNumber += digitToInt(i_BinaryNumber[currentDigit]) * digitWeight;
				digitWeight *= (int)eBase.Two;
			}

			return decimalNumber;
		}

		private static int digitToInt(char digit)
		{
			return digit - '0';
		}

		private static void isDownwardSeries(int i_DecimalNumber)
		{
			bool isDownwardSeries = true;
			int currentDigit, nextDigit;
			while (isDownwardSeries && i_DecimalNumber >= (int)eBase.Ten)
			{
				i_DecimalNumber = Math.DivRem(i_DecimalNumber, (int)eBase.Ten, out currentDigit);
				nextDigit = i_DecimalNumber % (int)eBase.Ten;
				isDownwardSeries = nextDigit > currentDigit;
			}

			if (isDownwardSeries)
			{
				s_IsDownwardSeries++;
			}
		}

		private static void printStatistics(int[] decimalNumbers)
		{
			string.Format(
@"The decimal number values are: {0}, {1}, {2}.{8}
The avg number of zeroes in each number is: {3:F3} {8}
The avg number of Ones in each number is: {4:F3} {8}
There are {5} numbers which are a power of 2.{8}
There are {6} numbers which present a strong downwards series.{8}
The avg sum of all the numbers is: {7:F3} {8}",
			decimalNumbers[0],
			decimalNumbers[1], 
			decimalNumbers[2], 
			s_AvgNumOfZeros,
			s_AvgNumOfOnes,
			s_PowerOfTwoCounter,
			s_IsDownwardSeries,
			s_AvgSumOfNumbers,
			System.Environment.NewLine);
		}
	}
}
