using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
	
	class Program
	{
		static void Main(string[] args)
		{
			int depart = 14;
			int arrivee = 26;
			const int nbrSommets = 30;

			string path = "C:/Users/akoch2/Desktop/systèmes complexes/ConsoleApp1/distances.txt";
			Graph graphJeu = createGraph(path, nbrSommets);

			List<int> pluscourtchemin = graphJeu.dijkstra(depart, arrivee);
			foreach (var item in pluscourtchemin)
			{
				Console.WriteLine(item);
			}

			//test du graph du cours
			/*
			List<int> plusCourtExempleCours = testDijkstraExempleCours() ;
			foreach (var item in plusCourtExempleCours)
			{
				Console.WriteLine(item);}
			*/

		}

		public static Graph createGraph(string path, int nbrSommets)
		{
			const int inf = int.MaxValue; //infini

			Graph graph = new Graph(nbrSommets, new int[nbrSommets, nbrSommets]);
			for (int i = 0; i < nbrSommets; i++)
			{
				for (int j = 0; j < nbrSommets; j++)
				{
					graph.ponderation[i, j] = inf;
				}

			}

			string[] readText = File.ReadAllLines(path);
			//Console.WriteLine(readText.Length);
			//int nbrChemins = readText.Length;
			foreach (string s in readText)
			{
				string[] subs = s.Split(' ');
				graph.ponderation[int.Parse(subs[0]), int.Parse(subs[1])] = int.Parse(subs[2]);
				graph.ponderation[int.Parse(subs[1]), int.Parse(subs[0])] = int.Parse(subs[2]);
			}

			return graph;
		}


		public static List<int> testDijkstraExempleCours()
		{
			int depart = 0;
			int arrivee = 9;
			const int inf = int.MaxValue;
			const int nbrSommets = 10;
			//le graph du cours a été orienté du haut vers le bas
			Graph graphCoursOriente = new Graph(nbrSommets, new int[nbrSommets, nbrSommets] {    { inf, 85, 217, inf, 173, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, 80, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, 186, 103, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, 502},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, 250, inf},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf},
																				{ inf, inf, inf, 183, inf, inf, inf, inf, inf, 167},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, 84},
																				{ inf, inf, inf, inf, inf, inf, inf, inf, inf, inf}});
			return graphCoursOriente.dijkstra(depart, arrivee);
		}
	}


	class Graph
	{
		const int inf = int.MaxValue;

		public int[,] ponderation;
		//private Dictionary<int, string> nomSommets { get; set; } //unused
		private int nbrSommets;

		public Graph(int nbrSommets, int[,] ponderation)
		{
			this.ponderation = ponderation;
			this.nbrSommets = nbrSommets;
		}

		public List<int> dijkstra(int depart, int arrivee) {
			List<int> listSommets = new List<int>();
			int[] distances = new int[nbrSommets]; //distance entre le sommet de départ et un autre sommet i
			int[] predecesseur = new int[nbrSommets]; //predessesseur du sommet i

			for (int i = 0; i < nbrSommets; i++)
			{
				distances[i] = inf;
				listSommets.Add(i);
			}

			distances[depart] = 0;
			int som = depart;

			while (listSommets.Count > 0)
			{
				//Console.WriteLine(som);
				listSommets.Remove(som);

				foreach (var b in listSommets)
				{
					if (ponderation[som, b] == inf) { continue; } //si ce n'est pas un voisin de som, continuer la boucle
					//Console.WriteLine("le point "+b + " est à une distance de "+depart+" de " + distances[b] + " ou " + (distances[som] + ponderation[som, b]));
					if (distances[b] > (distances[som] + ponderation[som, b])){
						distances[b] = distances[som] + ponderation[som, b];
						predecesseur[b] = som;
					}
					
				}
				int min = inf;
				int previoussom = som;
				//quel est le sommet avec le plus court chemin du départ :
				//Console.WriteLine("nombre de sommets non testés : "+listSommets.Count);
				foreach (var b in listSommets)
                {
                    if (distances[b] < min)
                    {
						som = b;
						min = distances[b];
                    }
                }
				if(som == previoussom){break;} //si le nouveau sommet n'a pas changé, c'est que certains points ne sont pas connectés au sommet de départ, l'algo risque alors de boucler à l'infini
				//Console.WriteLine("-------prochain point-------");
			}

			//list des sommets du chemin le plus court
			List<int> shortestPath = new List<int>();
			int current = arrivee;
			while (current != depart)
			{
				shortestPath.Add(current);
				current = predecesseur[current];
			}

			shortestPath.Reverse();

			return shortestPath;
		}
	}
}
