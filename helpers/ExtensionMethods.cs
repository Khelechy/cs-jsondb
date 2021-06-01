using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_jsondb.helpers
{
	public static class ExtensionMethods
	{
		public static JArray toDataList(this object data)
		{
			if (data != null)
			{
				try
				{
					JArray dataArray = (JArray)data;
					return dataArray;
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex);
					return null;
				}
			}
			else
			{
				return null;
			}
		}
	}
}
