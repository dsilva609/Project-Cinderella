using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Helpers
{
	public static class ListHelpers
	{
		public static List<T> GetRandom<T>(this List<T> list, int count)
		{
			if (count > list.Count) count = list.Count;

			return list.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
		}
	}
}