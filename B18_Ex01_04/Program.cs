using System;

namespace B18_Ex01_04
{
	public class Program
	{
		public	static	void	Main()
		{
			bool	isNumberString;
			string	userInput;

			userInput = readInput();
			isNumberString = isAllNumbers(userInput);
			printInputInformation(isNumberString, userInput);
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		private static	void	printInputInformation(bool i_IsNumberString, string i_UserInput)
		{
			bool	isPalindrome;
			bool	parity;
			int		lowerCaseNumber;

			isPalindrome = checkIfPalindrome(i_UserInput);
			Console.WriteLine("{1}The string is a Palindrome: {0}", isPalindrome ? "Yes" : "No", System.Environment.NewLine);
			if (i_IsNumberString)
			{
				parity = checkParity(i_UserInput);
				Console.WriteLine("The numbers parity is: {0}", parity ? "Even" : "Odd");
			}
			else
			{
				lowerCaseNumber = howManyLowerCaseLetters(i_UserInput);
				Console.WriteLine("There are {0} lower case letters.", lowerCaseNumber );
			}
		}

		private static	string	readInput()
		{
			string userInput;

			Console.WriteLine("Please enter a 8 character long string: ");
			userInput = Console.ReadLine();
			while (!isValidInput(userInput))
			{
				Console.WriteLine("Invalid input!");
				Console.WriteLine("Please enter a valid 8 character long string: ");
				userInput = Console.ReadLine();
			}

			return userInput;
		}

		private static	int		howManyLowerCaseLetters(string i_UserInput)
		{
			int lowerCaseLetters = 0;
			
			foreach (char currentLetter in i_UserInput)
			{
				if (char.IsLower(currentLetter))
				{
					lowerCaseLetters++;
				}
			}

			return lowerCaseLetters;
		}

		private static	bool	checkParity(string i_UserInput)
		{
			int userInputNumber = int.Parse(i_UserInput);
			return userInputNumber % 2 == 0;
		}

		private static	bool	checkIfPalindrome(string i_UserInput)
		{
			bool isPalindrome = true;

			for (int left = 0, right = i_UserInput.Length - 1; left < right; left++, right--)
			{
				isPalindrome = isPalindrome && (char.ToLower(i_UserInput[left]) == char.ToLower(i_UserInput[right]));
			}

			return isPalindrome;
		}

		private static	bool	isValidInput(string i_UserInput)
		{
			bool isValid = i_UserInput.Length == 8;

			if (isValid)
			{
				isValid = isAllLetters(i_UserInput);
				if (!isValid)
				{
					isValid = isAllNumbers(i_UserInput);
				}
			}

			return isValid;
		}

		private static	bool	isAllLetters(string i_UserInput)
		{
			bool isValid = true;

			foreach (char currentLetter in i_UserInput)
			{
				isValid = isValid && char.IsLetter(currentLetter);
			}

			return isValid;
		}

		private	static	bool	isAllNumbers(string i_UserInput)
		{
			bool isValid = true;

			foreach (char currentDigit in i_UserInput)
			{
				isValid = isValid && char.IsDigit(currentDigit);
			}

			return isValid;
		}
	}
}
