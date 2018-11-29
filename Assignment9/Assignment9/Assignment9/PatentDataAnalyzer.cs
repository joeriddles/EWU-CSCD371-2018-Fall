using System.Collections.Generic;
using System.Linq;

namespace PatentData
{
	public static class PatentDataAnalyzer
	{
		public static List<string> InventorNames(string country)
		{
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

			IEnumerable<long> inventorIds = patents.SelectMany(patent => patent.InventorIds.Select(id => id));

			var numPatents = inventors.Join(
				inventorIds,
				inventor => inventor.Id,
				id => id,
				(inventor, id) => inventor
			).ToList();

			Dictionary<Inventor, int> numPatentsByInventorId = new Dictionary<Inventor, int>();
			inventors.ForEach(inventor => numPatentsByInventorId.Add(inventor, 0));
			numPatents.ForEach(inventor => numPatentsByInventorId[inventor]++);

			return numPatentsByInventorId.Where(kvp => kvp.Value >= n).Select(kvp => kvp.Key).ToList();
		}

		private static bool IsNullOrEmpty<T>(this List<T> list)
		{
			if (list == null || !list.Any())
				return true;
			return false;
		}
	}
}
