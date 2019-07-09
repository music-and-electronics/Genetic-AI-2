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
        int probability;
        string raw_json_data { get; set; }

        public Genetic_Json_Data()
        {
            Json_parser();
            Initialize();
             Survive(Genetic_Set, genetic_target_data);
            //while (Score_Calculation(Survived_Genes[0], genetic_target_data) > 10)
            {
                Gene_generator(Survived_Genes);
                Survive(Genetic_Set, genetic_target_data);

            }
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

            for (int i=0;i<Genetic_Set.Count;i++)
            {
                for (int k=0;k<Survived_Genes[0].Length;k++)
                {


                }
            }
            Survived_Genes.RemoveAt(0);
            Survived_Genes.RemoveAt(0);
        }

        private void Survive(List<int[]> Genetic_Set, int[] genetic_target_data)
        {
            List<Score_Data> Score = new List<Score_Data>();
            foreach(int[] gene in Genetic_Set)
            {
                Score.Add(new Score_Data(Score_Calculation(genetic_target_data,gene),gene));
            }

            Score.Sort(
                delegate (Score_Data A, Score_Data B)
                {
                    if (A.score > B.score) return 1;
                    else if (A.score == B.score) return 0;
                    else return -1;
                }
            );


            Survived_Genes.Add((Score[0].gene_data));
            Survived_Genes.Add((Score[1].gene_data));

            foreach(Score_Data score_Data in Score)
            {
                Console.Write(score_Data.score+":");
                for(int i=0;i<score_Data.gene_data.Length;i++)
                {
                    Console.Write(score_Data.gene_data[i]);
                }
                Console.WriteLine();
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

    public class Score_Data
    {
        public int score { get; set; }
        public int[] gene_data { get; set; }
        public Score_Data(int tmp_score, int[] tmp_gene_data)
        {
            gene_data = tmp_gene_data;
            score = tmp_score;
        }

    }
}
