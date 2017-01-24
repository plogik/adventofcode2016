using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_2
{
    public enum Directions { L, R }
    enum Aim { N, S, E, W }

	delegate Point MoverDelegate(Point point, uint numSteps);

    public class Navigator
    {
		private List<Point> history = new List<Point>() { new Point() { X = 0, Y = 0 } };
        private Aim currentAim = Aim.N;

        public Point CurrentPosition { set; get; }

        public void Move(Directions direction, uint numSteps)
        {
			var oldPos = CurrentPosition;
			CurrentPosition = GetMover(direction).Invoke(CurrentPosition, numSteps);
			currentAim = CalculateNewAim(direction);
			AddStepsToHistoryFrom(oldPos);
		}

		public int DistanceToFirstCrossing()
		{
			Point firstCrossing = new Point();
			bool found = false;
			for (int i = 0; i < history.Count; i++)
			{
				for (int j = i + 1; j < history.Count; j++)
				{
					if (history[j].Equals(history[i]))
					{
						found = true;
						firstCrossing = history[i];
						break;
					}
				}
				if (found)
					break;
			}
			return Math.Abs(firstCrossing.X) + Math.Abs(firstCrossing.Y);
		}

		private void AddStepsToHistoryFrom(Point old)
		{
			while (old.X != CurrentPosition.X)
			{
				if (old.X < CurrentPosition.X)
					old.X++;
				else
					old.X--;
				history.Add(old);
			}
			while (old.Y != CurrentPosition.Y)
			{
				if (old.Y < CurrentPosition.Y)
					old.Y++;
				else
					old.Y--;
				history.Add(old);
			}
		}


		private Aim CalculateNewAim(Directions direction)
		{
			return
				currentAim == Aim.N && direction == Directions.L ? Aim.W :
				currentAim == Aim.N && direction == Directions.R ? Aim.E :
				currentAim == Aim.S && direction == Directions.L ? Aim.E :
				currentAim == Aim.S && direction == Directions.R ? Aim.W :
				currentAim == Aim.W && direction == Directions.L ? Aim.S :
				currentAim == Aim.W && direction == Directions.R ? Aim.N :
				currentAim == Aim.E && direction == Directions.L ? Aim.N :
				Aim.S; // currentAim == Aim.E && direction == Directions.R
		}

		private MoverDelegate GetMover(Directions direction)
		{
			return
				currentAim == Aim.N && direction == Directions.L ? new MoverDelegate(XNegative) :
				currentAim == Aim.N && direction == Directions.R ? new MoverDelegate(XPositive) :
				currentAim == Aim.S && direction == Directions.L ? new MoverDelegate(XPositive) :
				currentAim == Aim.S && direction == Directions.R ? new MoverDelegate(XNegative) :
				currentAim == Aim.W && direction == Directions.L ? new MoverDelegate(YNegative) :
				currentAim == Aim.W && direction == Directions.R ? new MoverDelegate(YPositive) :
				currentAim == Aim.E && direction == Directions.L ? new MoverDelegate(YPositive) :
					new MoverDelegate(YNegative); // currentAim == Aim.E && direction == Directions.R

		}

		private static Point YNegative(Point point, uint numSteps)
		{
			return new Point() { X = point.X, Y = point.Y - (int)numSteps };
		}
		private static Point YPositive(Point point, uint numSteps)
		{
			return new Point() { X = point.X, Y = point.Y + (int)numSteps };
		}
		private static Point XNegative(Point point, uint numSteps)
		{
			return new Point() { X = point.X - (int)numSteps, Y = point.Y };
		}
		private static Point XPositive(Point point, uint numSteps)
		{
			return new Point() { X = point.X + (int)numSteps, Y = point.Y };
		}
	}
}
