using System.Collections.Generic;

namespace Day1_1
{


	public class StepsParser
	{
		public static List<DirectionAndSteps> Parse(string input)
		{
			string[] parts = input.Split(',');
			List<DirectionAndSteps> results = new List<DirectionAndSteps>();
			foreach (string part in parts)
			{
				string trimmed = part.Trim();
				if (string.IsNullOrEmpty(trimmed))
					continue;
				Directions dir = trimmed.StartsWith("L") ?
					Directions.L : Directions.R;
				uint steps = uint.Parse(trimmed.Substring(1));
				results.Add(new DirectionAndSteps() { Direction = dir, Steps = steps });
			}

			return results;
		}
	}
}
