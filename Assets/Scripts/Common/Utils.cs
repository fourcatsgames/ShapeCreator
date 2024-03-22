using System.Text.RegularExpressions;

namespace Common
{
	public static class Utils
	{
		
		public static string RemoveZWSP(string input, string replacement)
		{
			return input.Replace("\u200B", replacement);

		}
	}
}
