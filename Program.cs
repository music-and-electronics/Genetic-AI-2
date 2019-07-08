using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;


namespace Genetic_AI_Demo
{
    class Genetic_Json_Data
    {
        JObject json_object;
        string raw_json_data;

        public Genetic_Json_Data()
        {
            raw_json_data = File.ReadAllText("C:/Users/kjh97/source/repos/Genetic AI Demo/Genetic_Data.json");
            json_object = JObject.Parse(raw_json_data);
        }      

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Genetic_Json_Data Genetic_Json_Data = new Genetic_Json_Data();
            
        }
    }
}
