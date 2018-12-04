using System;
using System.Collections.Generic;
using System.Linq;

namespace PatentData
{
	public static class PatentDataAnalyzer
	{
		public static List<string> InventorNames(string country)
		{
			if (country is null) throw new NullReferenceException();

			return PatentData.Inventors
				.Where(inventor => inventor.Country.Equals(country))
				.Select(inventor => inventor.Name)
				.ToList();
		}

		public static List<string> InventoryLastNames()
		{
			return PatentData.Inventors
				.OrderByDescending(inventor => inventor.Id)
				.Select(inventor => inventor.Name.Split().Last())
				.ToList();
		}

		public static string LocationsWithInventors()
		{
			return string.Join(",",
				PatentData.Inventors
					.Select(inventor => $"{inventor.State}-{inventor.Country}")
					.Distinct()
				);
		}

		public static List<Inventor> GetInventorsWithMultiplePatents(int n)
		{
			var inventors = PatentData.Inventors?.ToList();
			var patents = PatentData.Patents?.ToList();

			if (inventors.IsNullOrEmpty() || patents.IsNullOrEmpty())
				return null;

			return inventors.Where(inventor =>
			{
				int count = patents.Count(patent => patent.InventorIds.Contains(inventor.Id));
				return count >= n;
			}).ToList();
		}

		private static bool IsNullOrEmpty<T>(this List<T> list)
		{
			if (list == null || !list.Any())
				return true;
			return false;
		}

	}
}
