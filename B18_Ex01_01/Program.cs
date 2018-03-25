using System;


namespace B18_Ex01_01
{
	public static class Program
	{
		enum eBase { Two = 2, Ten = 10 };
		const int numberOfInputs = 3;
		const int expectedBinaryNumberLength = 9;

		static float m_avgNumOfZeros;
		static float m_avgNumOfOnes;
		static int m_powerOfTwoCounter;
		static int m_isDownwardSeries;
		static float m_avgSumOfNumbers;

		public static void Main()
		{
			
			BinaryAnalyzer();
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public static void BinaryAnalyzer()
		{
			int[] decimalNumbers = new int[numberOfInputs];
			for (int i = 0; i < numberOfInputs; i++)
			{
				Console.WriteLine("Please enter a binary number (9 digits long): ");
				decimalNumbers[i] = HandleBinaryNumber();
			}
			m_avgSumOfNumbers /= (float)numberOfInputs;
			m_avgNumOfOnes /= (float)numberOfInputs;
			m_avgNumOfZeros /= (float)numberOfInputs;
			PrintStatistics(decimalNumbers);
		}

		private static int HandleBinaryNumber()
		{
			string binaryNumber = ReadBinary();
			CountOnesAndZeroes(binaryNumber);
			IsAPowerOfTwo(binaryNumber);
			int decimalNumber = BinaryToInt(binaryNumber);
			IsDownwardSeries(decimalNumber);
			m_avgSumOfNumbers += decimalNumber;
			return decimalNumber;
		}

		private static string ReadBinary()
		{
			string binaryNumber = Console.ReadLine();
			while (!IsLegalBinaryNumber(binaryNumber))
			{
				Console.WriteLine("Please enter a valid binary number (9 bits long):");
				binaryNumber = Console.ReadLine();
			}
			return binaryNumber;
		}

		private static bool IsLegalBinaryNumber(string i_binaryNumber)
		{

			System.Text.RegularExpressions.Regex isBinary = new System.Text.RegularExpressions.Regex(@"^[01]{9}$");
			return isBinary.IsMatch(i_binaryNumber);

			//No need - swapped with a regex above
			//bool isBinary = i_binaryNumber.Length == expectedBinaryNumberLength;
			//if (isBinary)
			//{
			//	for (int currentDigit = 0; isBinary && currentDigit < i_binaryNumber.Length; currentDigit++)
			//	{
			//		isBinary = (i_binaryNumber[currentDigit] == '0' || i_binaryNumber[currentDigit] == '1');
			//	}
			//}

		}

		private static void CountOnesAndZeroes(string i_binaryNumber)
		{
			foreach (char currentDigit in i_binaryNumber)
			{
				if (currentDigit == '1')
					m_avgNumOfOnes++;
				else
					m_avgNumOfZeros++;
			}
		}

		private static void IsAPowerOfTwo(string i_binaryNumber)
		{
			int howManyOnes = 0;
			foreach (char currentDigit in i_binaryNumber)
			{
				if (currentDigit == '1')
					howManyOnes++;
			}
			if (howManyOnes == 1)
				m_powerOfTwoCounter++;
		}

		private static int BinaryToInt(string i_binaryNumber)
		{
			int digitWeight = 1;
			int decimalNumber = 0;
			for (int currentDigit = i_binaryNumber.Length - 1; currentDigit >= 0; currentDigit--)
			{
				decimalNumber += (DigitToInt(i_binaryNumber[currentDigit]) * digitWeight);
				digitWeight *= (int)eBase.Two;
			}
			return decimalNumber;
		}

		private static int DigitToInt(char digit)
		{
			return digit - '0';
		}

		private static void IsDownwardSeries(int i_decimalNumber)
		{
			bool isDownwardSeries = true;
			int currentDigit, nextDigit;
			while (isDownwardSeries && i_decimalNumber >= (int)eBase.Ten)
			{
				i_decimalNumber = Math.DivRem(i_decimalNumber, (int)eBase.Ten, out currentDigit);
				//Swapped with System.Math.DivRem(int a, int b, out int Remainder), returns a/b, and remainder as output paramater
				//currentDigit = i_decimalNumber % (int)eBase.Ten;
				//i_decimalNumber /= (int)eBase.Ten;
				nextDigit = i_decimalNumber % (int)eBase.Ten;
				if (nextDigit <= currentDigit)
					isDownwardSeries = false;
			}
			if (isDownwardSeries)
				m_isDownwardSeries++;
		}

		private static void PrintStatistics(int[] decibalNumbers)
		{
			Console.WriteLine(
@"The decimal number values are: {0}, {1}, {2}.
The avg number of zeroes in each number is: {3:F3})
The avg number of Ones in each number is: {4:F3}
There are {5} numbers which are a power of 2.
There are {6} numbers which present a strong downwards series.
The avg sum of all the numbers is: {7:F3}"
			,decibalNumbers[0], decibalNumbers[1], decibalNumbers[2], m_avgNumOfZeros, m_avgNumOfOnes, m_powerOfTwoCounter, m_isDownwardSeries, m_avgSumOfNumbers);
		}
	}
}
