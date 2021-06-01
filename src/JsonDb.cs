using System;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using cs_jsondb.helpers;
using System.Collections.Generic;

public static class JsonDb{
    public static string jsonFile;
    public static string jsonLocation;
    private static JObject _dbObject;

    public static JObject load(string filePathLoaded){
        if(!File.Exists(filePathLoaded))
            throw new Exception("File does not exist, please check file or file path");
        jsonFile = File.ReadAllText(filePathLoaded);
        jsonLocation = filePathLoaded;
       return  _dbObject = JObject.Parse(jsonFile);
    }

    public static object select(this object data, string key = ""){
		try
		{
			if (data != null)
			{
                var parsedData = JObject.Parse(data.ToString());
                var result = (object)parsedData[key];
                Console.WriteLine("Selected Data Result: " + result.ToString());
                return result;
			}
			else
			{
                throw new Exception("The preloaded data is null");
			}
        }
		catch (NullReferenceException ex)
		{
            Console.WriteLine(ex);
            Console.WriteLine("No such table as: " + key);
            return null;
		}
        
    }

	public static object where(this object data, string key = "", dynamic value = null)
	{
        if(data != null)
		{
            var dataArray = data.toDataList();
            Console.WriteLine("This is the Data Array: " + dataArray);
            var newDataArray = new List<object>();
            foreach(var singleData in dataArray.Where(x => x[key] == value))
			{
                newDataArray.Add(singleData);
			}
            var xx = newDataArray;
            return newDataArray;
		}
		else
		{
            return null;
		}
        
	}

    public static void add(this object data, string table, object newData)
	{
        if(data != null)
		{
            var parsedData = JObject.Parse(data.ToString());
            var result = (object)parsedData[table];
            var dataArray = result.toDataList();
            dataArray.Add(JObject.Parse(JsonConvert.SerializeObject(newData, Formatting.Indented)));
            parsedData[table] = dataArray;
            string newJsonResult = parsedData.ToString();
            File.WriteAllText(jsonLocation, newJsonResult);
        }
	}

    public static void delete(this object data, string table, string key, dynamic value)
	{
        if (data != null)
        {
            var parsedData = JObject.Parse(data.ToString());
            var result = (object)parsedData[table];
            var dataArray = result.toDataList();
            var itemToBeDeleted = dataArray.FirstOrDefault(x => x[key] == value);
            dataArray.Remove(itemToBeDeleted);
            parsedData[table] = dataArray;
            string newJsonResult = parsedData.ToString();
            File.WriteAllText(jsonLocation, newJsonResult);
        }
    }

    public static void update(this object data, string table, string key, dynamic value)
	{

	}
}