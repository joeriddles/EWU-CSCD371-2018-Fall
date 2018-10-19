using System;

namespace CalendarItems
{
	public static class Application
	{
		public static string Display(Object obj)
		{
			switch (obj)
			{
				case Course course:
					return course.GetSummaryInformation();
				case Event evnt:
					return evnt.GetSummaryInformation();
				case CalendarItem ci:
					return ci.GetSummaryInformation();
				case Object objct:
					return objct.ToString(); 
				default: throw new ArgumentException();
			}
		}
	}
}
