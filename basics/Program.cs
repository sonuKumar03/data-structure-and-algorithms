using System;
using System.Collections.Generic;
using DataStructure.Graph;
using System.IO;
namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = @"C:\Users\Sonu\source\repos\basics\basics\input.txt";
            int edges = int.Parse(File.ReadAllLines(inputFilePath)[0].Split(" ")[0])+1;
            int vertices =int.Parse(File.ReadAllLines(inputFilePath)[0].Split(" ")[1])+1;

            List<List<int>> adj = new List<List<int>>(edges);
            for(int i = 1; i <= edges; i++)
            {
                adj.Add(new List<int>());
            }
            foreach(var line in File.ReadLines(inputFilePath))
            {
                var str = line.Split(" ");
                int v = int.Parse(str[0]);
                int u = int.Parse(str[1]);
                adj[u].Add(v);
                adj[v].Add(u);
            }

            Traversal traversal = new Traversal();
            List<int> storefDfsNonRec = traversal.BfsOfGraph(adj, vertices);
            foreach (var t in storefDfsNonRec)
            {
                Console.Write(t + ",");
            }
            Console.WriteLine();
           
        }
    }
}
