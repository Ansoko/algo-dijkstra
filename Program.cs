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
			graphCoursOriante.dijkstra(0, 9);
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
			List<int> listSommets = new List<int>();
			int[] distances = new int[nbrSommets]; //distance entre le sommet de départ et un autre sommet i
			int[] predecesseur = new int[nbrSommets]; //predessesseur du sommet i

			for (int i = 0; i < nbrSommets; i++)
			{
				distances[i] = inf;
				listSommets.Add(i);
			}

			distances[depart] = 0;
			listSommets.Remove(depart);

			int som = depart;
			var temp = (0,0);
			int distdesom, tempsom=0;
			while (listSommets.Count > 0)
			{
				temp = distMin(som, listSommets);
				//som = temp.Item1;
				distances[temp.Item1] = temp.Item2;
				Console.WriteLine(som + ", à distance de : "+distances[som]);
				listSommets.Remove(som);

				distdesom = inf;
				foreach (var b in listSommets)
				{
					if (ponderation[som, b] == inf) { continue; } //si ce n'est pas un voisin de som, continuer la boucle
					Console.WriteLine(b + ", et il est à de 0 : " + distances[b] + " et " + (distances[som] + ponderation[som, b]));
					if (distances[b] > (distances[som] + ponderation[som, b])){
						distances[b] = distances[som] + ponderation[som, b];
						predecesseur[b] = som;
					}
					if (distances[b] < distdesom) {
						distdesom = distances[b];
						tempsom = b;
					}
					
				}
				som = tempsom;
				Console.WriteLine("gooooooooooooooooooooooo");
			}

			return new List<int>();
		}

		//retourne le point le plus proche de "départ" et sa distance
		private (int,int) distMin(int depart, List<int> listSommets) 
		{
			int mini = inf;
			int s = -1; //sommet
			foreach (var som in listSommets)
			{
				if (ponderation[depart,som]<mini)
				{
					mini = ponderation[depart, som];
					//Console.WriteLine(mini);
					s = som;
				}
			}
			return (s,mini);
		}
	}
}
