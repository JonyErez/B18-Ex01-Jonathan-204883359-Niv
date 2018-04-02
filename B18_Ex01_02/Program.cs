using System;
using System.Text;

namespace B18_Ex01_02
{
	public class Program
	{
		public	static	void			Main()
		{
			uint hourglassHeight = 5;

			Console.WriteLine(Hourglass(hourglassHeight));
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public	static	StringBuilder	Hourglass(uint i_HourglassHeight)
		{
			StringBuilder myHourglass = new StringBuilder();
			i_HourglassHeight = evenToOdd(i_HourglassHeight);
			buildTopHalfOfHourglass(myHourglass, i_HourglassHeight);
			buildTBottomHalfOfHourglass(myHourglass, i_HourglassHeight);

			return myHourglass;
		}

		private	static	void			buildTopHalfOfHourglass(StringBuilder i_MyHourglass, uint i_HourglassHeight)
		{
			for (uint currentHourglassLine = 0; currentHourglassLine < (i_HourglassHeight / 2) + 1; currentHourglassLine++)
			{
				addCurrentHourglassLine(i_MyHourglass, i_HourglassHeight, currentHourglassLine);
			}
		}

		private static	void			buildTBottomHalfOfHourglass(StringBuilder i_MyHourglass, uint i_HourglassHeight)
		{
			for (uint currentHourglassLine = (i_HourglassHeight / 2) + 1; currentHourglassLine < i_HourglassHeight; currentHourglassLine++)
			{
				addCurrentHourglassLine(i_MyHourglass, i_HourglassHeight, i_HourglassHeight - currentHourglassLine - 1);
			}
		}

		private static	void			addCurrentHourglassLine(StringBuilder i_MyHourglass, uint i_HourglassHeight, uint i_CurrentHourglassLine)
		{
			addSymbolsToString(i_MyHourglass, ' ', i_CurrentHourglassLine);
			addSymbolsToString(i_MyHourglass, '*', i_HourglassHeight - (2 * i_CurrentHourglassLine));
			addSymbolsToString(i_MyHourglass, ' ', i_CurrentHourglassLine);
			i_MyHourglass.Append(System.Environment.NewLine);
		}

		private static	uint			evenToOdd(uint i_NumberToConvert)
		{
			if (i_NumberToConvert % 2 == 0)
			{
				i_NumberToConvert++;
			}

			return i_NumberToConvert;
		}

		private static	void			addSymbolsToString(StringBuilder i_MyHourglass, char i_Symbol, uint i_NumberOfTimes)
		{
			for (int i = 0; i < i_NumberOfTimes; i++)
			{
				i_MyHourglass.Append(i_Symbol);
			}
		}
	}
}
