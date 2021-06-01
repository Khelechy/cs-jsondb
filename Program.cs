using cs_jsondb.helpers;
using System;
using System.Reflection;

namespace cs_jsondb
{
	class Program
	{
		static void Main(string[] args)
		{
			var db = JsonDb.load(@"C:\Users\kelechi.onyekwere\source\repos\cs-jsondb\test2.json");
			//var newPost = new
			//{
			//	userId = 200,
			//	id = 2000,
			//	title = "Newly added post",
			//	completed = true
			//};
			//db.add("posts", newPost);
			var updatePost = new
			{
				userId = 50
			};
			db.update("posts", "id", 2000, updatePost);
			//posts.add(newPost);
			//var postss = posts.where("completed", false);
			//db.LoadJsonDbx(@"test.json");
			//db.delete("posts", "id", 2000);

		}
	}
}
