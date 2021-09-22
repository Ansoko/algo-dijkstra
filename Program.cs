using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	
	class Program
	{
		static void Main(string[] args)
		{
			const int inf = int.MaxValue;
			const int nbrSommets = 10;
			//le graph du cours a été orienté du haut vers le bas
			Graph graphCoursOriante = new Graph(nbrSommets, new int[nbrSommets,nbrSommets] {	{ inf, 85, 217, inf, 173, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, 80, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, 186, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, 502},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, 250, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, 183, inf, inf, inf, inf, inf, 167},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, 84},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf}});
			
			Console.WriteLine("Hello World!");
		}
	}


	class Graph
	{
		const int inf = int.MaxValue;

		private int[,] ponderation;
		//private Dictionary<int, string> nomSommets { get; set; } //unused
		private int nbrSommets;

		public Graph(int nbrSommets, int[,] ponderation)
		{
			this.ponderation = ponderation;
			this.nbrSommets = nbrSommets;
		}

		public List<int> dijkstra(int depart, int arrivee) {
			List<int> sousGraph = new List<int>();
			List<int> listSommets = new List<int>();
			sousGraph.Add(depart);
			int[] distances = new int[nbrSommets];
			for (int i = 0; i < distances.Length; i++)
			{
				distances[i] = inf;
				listSommets[i] = i;
			}
			distances[depart] = 0;

			while (sousGraph.Count < nbrSommets)
			{

			}

			return new List<int>();
		}

		private int distMin(Graph g, int depart)
		{
			int mini = inf;
			int s; //sommet
			for (int i = 0; i < g.Length; i++)
			{

			}
			return int;
		}
	}
}
