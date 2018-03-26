using System;
using System.Text;

namespace B18_Ex01_02
{
	public static class Program
	{
		public static void Main()
		{
			Hourglass();
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public static void Hourglass()
		{
			Console.WriteLine(Hourglass(5));
		}


		public static StringBuilder Hourglass(int i_HourglassHeight)
		{
			StringBuilder myHourglass = new StringBuilder((i_HourglassHeight * i_HourglassHeight) + i_HourglassHeight);
			BuildTopHalfOfHourglass(myHourglass, i_HourglassHeight);
			BuildTBottomHalfOfHourglass(myHourglass, i_HourglassHeight);
			return myHourglass;
		}

		public static void BuildTopHalfOfHourglass(StringBuilder i_myHourglass, int i_HourglassHeight)
		{
			for (int currentHourglassLine = 0; currentHourglassLine < (i_HourglassHeight / 2) + 1; currentHourglassLine++)
			{
				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_myHourglass.Append(' ');
				}

				for (int i = 0; i < i_HourglassHeight - (2 * currentHourglassLine); i++)
				{
					i_myHourglass.Append('*');
				}

				for (int i = 0; i < currentHourglassLine; i++)
				{
					i_myHourglass.Append(' ');
				}
				i_myHourglass.Append(System.Environment.NewLine);
			}
		}

		public static void BuildTBottomHalfOfHourglass(StringBuilder i_myHourglass, int i_HourglassHeight)
		{
            for (int currentHourglassLine = (i_HourglassHeight/2) - 1; currentHourglassLine >= 0; currentHourglassLine--)
            {
                for (int i = 0; i < currentHourglassLine; i++)
                {
                    i_myHourglass.Append(' ');
                }

                for (int i = 0; i < i_HourglassHeight - (2 * currentHourglassLine); i++)
                {
                    i_myHourglass.Append('*');
                }

                for (int i = 0; i < currentHourglassLine; i++)
                {
                    i_myHourglass.Append(' ');
                }
                i_myHourglass.Append(System.Environment.NewLine);
            }
		}
	}
}
