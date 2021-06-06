using cs_jsondb.helpers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace cs_jsondb
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = JsonDb.load(@"C:\Users\kelechi.onyekwere\source\repos\cs-jsondb\test2.json");
			var result = db.select("users").where("idi", 4);
			Console.WriteLine(result);
		}
	}
}
