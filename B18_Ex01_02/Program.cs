using System;
using System.Text;

namespace B18_Ex01_02
{
	public static class Program
	{
		public static void Main()
		{
			Console.WriteLine(Hourglass(5));
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public static StringBuilder Hourglass(int i_HourglassHeight)
		{
			StringBuilder myHourglass = new StringBuilder((i_HourglassHeight * i_HourglassHeight) + i_HourglassHeight);
			buildTopHalfOfHourglass(myHourglass, i_HourglassHeight);
			buildTBottomHalfOfHourglass(myHourglass, i_HourglassHeight);
			return myHourglass;
		}

		private static void buildTopHalfOfHourglass(StringBuilder i_MyHourglass, int i_HourglassHeight)
		{
			for (int currentHourglassLine = 0; currentHourglassLine < (i_HourglassHeight / 2) + 1; currentHourglassLine++)
			{
				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_MyHourglass.Append(' ');
				}

				for (int i = 0; i < i_HourglassHeight - (2 * currentHourglassLine); i++)
				{
					i_MyHourglass.Append('*');
				}

				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_MyHourglass.Append(' ');
				}
				i_MyHourglass.Append(System.Environment.NewLine);
			}
		}

		private static void buildTBottomHalfOfHourglass(StringBuilder i_MyHourglass, int i_HourglassHeight)
		{
			for (int currentHourglassLine = (i_HourglassHeight / 2) - 1; currentHourglassLine >= 0; currentHourglassLine--)
			{
				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_MyHourglass.Append(' ');
				}

				for (int i = 0; i < i_HourglassHeight - (2 * currentHourglassLine); i++)
				{
					i_MyHourglass.Append('*');
				}

				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_MyHourglass.Append(' ');
				}
				i_MyHourglass.Append(System.Environment.NewLine);
			}
		}
	}
}
