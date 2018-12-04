using System;
using System.Collections.Generic;
using System.Linq;

namespace PatentData
{
	public static class Enumerable
	{
		// Implements the Fisher-Yates shuffle method
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> enumerable)
		{
			List<T> list =  enumerable.ToList();
			Random randomNumGenerator = new Random();
			for (int i = list.Count - 1; i > 1; i--)
			{
				int j = randomNumGenerator.Next(list.Count);

				var temp = list[i];
				list[j] = list[i];
				list[i] = temp;
			}

			return list;
		}
	}
}
