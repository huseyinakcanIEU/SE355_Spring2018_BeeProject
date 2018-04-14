using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : ScriptableObject {

	
		public int weight = 0;
		public Vertex vertex;
	
		public Edge(int weight,Vertex vertex)
		{
			this.weight = weight;
			this.vertex = vertex;
		}
	
}
