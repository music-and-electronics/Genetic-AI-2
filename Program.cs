using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Genetic_AI_Demo
{
    class Genetic_Json_Data
    {
        JObject genetic_raw_object { get; set; }
        List<int[]> Genetic_Set = new List<int[]>();
        List<int[]> Survived_Genes = new List<int[]>();

        int[] genetic_target_data;
        string raw_json_data { get; set; }

        public Genetic_Json_Data()
        {
            Json_parser();
            Initialize();
             Survive(Genetic_Set, genetic_target_data);
        }
        
        private void Initialize( )
        {
            genetic_raw_object = JObject.Parse(raw_json_data);
            genetic_target_data = new int[(int)genetic_raw_object["Genetic Length"]];
            Gene_generator();
            Console.Write("Goal Data is: ");

            for(int i=0;i<(int)genetic_raw_object["Genetic Length"];i++)
            {
                Random random_generator = new Random();
                genetic_target_data[i] = random_generator.Next((int)genetic_raw_object["Genetic Range"][0], (int)genetic_raw_object["Genetic Range"][1]);
                Console.Write(genetic_target_data[i]);
            }

            Console.WriteLine();
        }

        private void Json_parser()
        {
            raw_json_data = File.ReadAllText("C:/Users/kjh97/source/repos/Genetic AI Demo/Genetic_Data.json");
            Console.WriteLine(raw_json_data);
        }

        private void Gene_generator()
        {
            for (int i = 0; i < (int)genetic_raw_object["Entity"]; i++)
            {
                int[] genetic_member = new int[(int)genetic_raw_object["Genetic Length"]];
                for (int k = 0; k < genetic_member.Length; k++)
                {
                    Random random_generator = new Random();
                    genetic_member[k] = random_generator.Next((int)genetic_raw_object["Genetic Range"][0], (int)genetic_raw_object["Genetic Range"][1]);
                    Console.Write(genetic_member[k]);

                }
                Console.WriteLine();
                Genetic_Set.Add(genetic_member);
            }

        }

        private void Gene_generator(List<int[]> Survived_Genes)
        { 
        }


        private void Survive(List<int[]> Genetic_Set, int[] genetic_target_data)
        {
            List<Dictionary<int, int[]>> Score = new List<Dictionary<int, int[]>>();
            foreach(int[] gene in Genetic_Set)
            {
                Dictionary<int, int[]> tmp_data = new Dictionary<int, int[]>();
                tmp_data[Score_Calculation(genetic_target_data, gene)] = gene;
                Score.Add(tmp_data);
            }
            foreach(Dictionary<int,int[]> values in Score  )
            {
                Console.WriteLine(values.ElementAt(0));
            }
        }


        private int Score_Calculation(int[] goal_gene, int[] operand_gene)
        {
            int temp_sum = 0;
            for(int i=0;i<goal_gene.Length;i++)
            {
                temp_sum += (goal_gene[i] - operand_gene[i]) * (goal_gene[i] - operand_gene[i]);
            }
            return temp_sum;
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
