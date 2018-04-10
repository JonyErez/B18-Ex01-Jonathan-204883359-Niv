using System;

namespace B18_Ex01_01
{
	public class Program
	{
		public	static	void	Main()
		{
			BinaryAnalyzer();
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public	static	void	BinaryAnalyzer()
		{
			int		howManyPowerOfTwo = 0, howManyDownwardSeries = 0;
			int		firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber;
			string	firstBinaryString, secondBinaryString, thirdBinaryString;
			float	sumOfNumbers = 0, sumOfOnes = 0;

			Console.WriteLine("Please enter the first binary number (9 digits long): ");
			firstBinaryString = readBinary();
			sumOfOnes += countOnes(firstBinaryString);
			howManyPowerOfTwo += isAPowerOfTwo(firstBinaryString);
			firstBinaryNumber = binaryToInt(firstBinaryString);
			howManyDownwardSeries += isDownwardSeries(firstBinaryNumber);
			sumOfNumbers += firstBinaryNumber;
			Console.WriteLine("Please enter the second binary number (9 digits long): ");
			secondBinaryString = readBinary();
			sumOfOnes += countOnes(secondBinaryString);
			howManyPowerOfTwo += isAPowerOfTwo(secondBinaryString);
			secondBinaryNumber = binaryToInt(secondBinaryString);
			howManyDownwardSeries += isDownwardSeries(secondBinaryNumber);
			sumOfNumbers += secondBinaryNumber;
			Console.WriteLine("Please enter the third binary number (9 digits long): ");
			thirdBinaryString = readBinary();
			sumOfOnes += countOnes(thirdBinaryString);
			howManyPowerOfTwo += isAPowerOfTwo(thirdBinaryString);
			thirdBinaryNumber = binaryToInt(thirdBinaryString);
			howManyDownwardSeries += isDownwardSeries(thirdBinaryNumber);
			sumOfNumbers += thirdBinaryNumber;
			printStatistics(
				firstBinaryNumber, 
				secondBinaryNumber, 
				thirdBinaryNumber, 
				sumOfNumbers, 
				sumOfOnes, 
				howManyPowerOfTwo, 
				howManyDownwardSeries);
		}

		private static	string	readBinary()
		{
			string binaryNumber;

			binaryNumber = Console.ReadLine();
			while (!isLegalBinaryNumber(binaryNumber))
			{
				Console.WriteLine("Invalid input!");
				Console.WriteLine("Please enter a valid binary number (9 bits long):");
				binaryNumber = Console.ReadLine();
			}

			return binaryNumber;
		}

		private static	bool	isLegalBinaryNumber(string i_BinaryNumber)
		{
			bool isBinary;
			ushort expectedBinaryNumberLength = 9;

			isBinary = i_BinaryNumber.Length == expectedBinaryNumberLength;
			if (isBinary)
			{
				for (int currentDigit = 0; isBinary && currentDigit < i_BinaryNumber.Length; currentDigit++)
				{
					isBinary = i_BinaryNumber[currentDigit] == '0' || i_BinaryNumber[currentDigit] == '1';
				}
			}

			return isBinary;
		}

		private static	int		countOnes(string i_BinaryNumber)
		{
			int numberOfOnes = 0;

			foreach (char currentDigit in i_BinaryNumber)
			{
				if (currentDigit == '1')
				{
					numberOfOnes++;
				}
			}

			return numberOfOnes;
		}

		private static	int		isAPowerOfTwo(string i_BinaryNumber)
		{
			int isPowerOfTwo = 0;
			
			if(countOnes(i_BinaryNumber) == 1)
			{
				isPowerOfTwo = 1;
			}

			return isPowerOfTwo;
		}

		private static	int		binaryToInt(string i_BinaryNumber)
		{
			int digitWeight = 1;
			int decimalNumber = 0;
			int twoBase = 2;

			for (int currentDigit = i_BinaryNumber.Length - 1; currentDigit >= 0; currentDigit--)
			{
				decimalNumber += digitToInt(i_BinaryNumber[currentDigit]) * digitWeight;
				digitWeight *= twoBase;
			}

			return decimalNumber;
		}

		private static	int		digitToInt(char i_Digit)
		{
			return i_Digit - '0';
		}

		private static	int		isDownwardSeries(int i_DecimalNumber)
		{
			int		isDownwardSeries = 1;
			int		currentDigit;
			int		nextDigit;
			int		decimalBase = 10;
			while (isDownwardSeries == 1 && i_DecimalNumber >= decimalBase)
			{
				i_DecimalNumber = Math.DivRem(i_DecimalNumber, decimalBase, out currentDigit);
				nextDigit = i_DecimalNumber % decimalBase;
				if(nextDigit > currentDigit)
				{
					isDownwardSeries = 0;
				}
			}

			return isDownwardSeries;
		}

		private static	void	printStatistics(
			int i_FirstBinaryNumber, 
			int i_SecondBinaryNumber, 
			int i_ThirdBinaryNumber,
			float i_SumOfNumbers, 
			float i_SumOfOnes, 
			int i_HowManyPowerOfTwo, 
			int i_HowManyDownwardSeries)
		{
			float numberOfInputs = 3, avgNumOfZeros, avgNumOfOnes, avgSumOfNumbers;
			string inputData;

			i_SumOfNumbers /= numberOfInputs;
			avgNumOfOnes = i_SumOfOnes / numberOfInputs;
			avgSumOfNumbers = i_SumOfNumbers / numberOfInputs;
			avgNumOfZeros = 9 - avgNumOfOnes;
			inputData = string.Format(
@"{8}The decimal number values are: {0}, {1}, {2}.
The avg number of zeroes in each number is: {3:F3}
The avg number of ones in each number is: {4:F3}
There are {5} numbers which are a power of 2.
There are {6} numbers which present a strong downwards series.
The avg sum of all the numbers is: {7:F3} {8}",
			i_FirstBinaryNumber,
			i_SecondBinaryNumber,
			i_ThirdBinaryNumber, 
			avgNumOfZeros,
			avgNumOfOnes,
			i_HowManyPowerOfTwo,
			i_HowManyDownwardSeries,
			avgSumOfNumbers,
			System.Environment.NewLine);
			Console.Write(inputData);
		}
	}
}
