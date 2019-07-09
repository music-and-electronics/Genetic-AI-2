using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;


namespace Genetic_AI_Demo
{
    class Genetic_Json_Data
    {
        JObject genetic_raw_object { get; set; }
        List<int[]> Genetic_Set = new List<int[]>();
        int[] genetic_goal_data;
        string raw_json_data { get; set; }

        public Genetic_Json_Data()
        {
            Json_parser();
            Initial_Gene_Generator();
        }
        
        private void Initial_Gene_Generator( )
        {
            genetic_raw_object = JObject.Parse(raw_json_data);
            genetic_goal_data = new int[(int)genetic_raw_object["Genetic Length"]];
            for(int i=0;i<(int)genetic_raw_object["Entity"];i++)
            {
                int[] genetic_member = new int[(int)genetic_raw_object["Genetic Length"]];
                for(int k=0;k<genetic_member.Length;k++)
                {
                    Random random_generator = new Random();
                    genetic_member[k] = random_generator.Next((int)genetic_raw_object["Genetic Range"][0], (int)genetic_raw_object["Genetic Range"][1]);
                    Console.Write(genetic_member[k]);

                }

                Console.WriteLine();
                Genetic_Set.Add(genetic_member);
            }
            Console.Write("Goal Data is: ");
            for(int i=0;i<(int)genetic_raw_object["Genetic Length"];i++)
            {
                Random random_generator = new Random();
                genetic_goal_data[i] = random_generator.Next((int)genetic_raw_object["Genetic Range"][0], (int)genetic_raw_object["Genetic Range"][1]);
                Console.Write(genetic_goal_data[i]);
            }

            Console.WriteLine();
        }

        private void Json_parser()
        {
            raw_json_data = File.ReadAllText("C:/Users/kjh97/source/repos/Genetic AI Demo/Genetic_Data.json");
            Console.WriteLine(raw_json_data);
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
