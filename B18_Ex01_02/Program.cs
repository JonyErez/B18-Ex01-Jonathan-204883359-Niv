using System;
using System.Text;

namespace B18_Ex01_02
{
	public static class Program
	{
		public static void Main()
		{
			SandClock();
			Console.WriteLine("Press 'enter' to exit!");
			Console.ReadLine();
		}

		public static void SandClock()
		{
			Console.WriteLine(SandClockBuilder(5));
		}


		public static StringBuilder SandClockBuilder(int i_clockHeight)
		{
			StringBuilder mySandClock = new StringBuilder((i_clockHeight * i_clockHeight) + i_clockHeight);
			BuildTopHalfOfSandClock(mySandClock, i_clockHeight);
			BuildTBottomHalfOfSandClock(mySandClock, i_clockHeight);
			return mySandClock;
		}

		public static void BuildTopHalfOfSandClock(StringBuilder i_mySandClock, int i_clockHeight)
		{
			for (int currentSandClockLine = 0; currentSandClockLine < (i_clockHeight / 2) + 1; currentSandClockLine++)
			{
				for (int i = 0; i < currentSandClockLine; i++)
				{
					i_mySandClock.Append(' ');
				}

				for (int i = 0; i < i_clockHeight - (2 * currentSandClockLine); i++)
				{
					i_mySandClock.Append('*');
				}

				for (int i = 0; i < currentSandClockLine; i++)
				{
					i_mySandClock.Append(' ');
				}
				i_mySandClock.Append(System.Environment.NewLine);
			}
		}

		public static void BuildTBottomHalfOfSandClock(StringBuilder i_mySandClock, int i_clockHeight)
		{
			for (int currentSandClockLine = i_clockHeight/2 - 1; currentSandClockLine >= 0; currentSandClockLine--)
			{
				for (int i=currentSandClockLine * (i_clockHeight+1); i< (currentSandClockLine + 1) * (i_clockHeight + 1); i++)
				{
					i_mySandClock.Append(i_mySandClock[i]);
				}
			}
		}


	}
}
