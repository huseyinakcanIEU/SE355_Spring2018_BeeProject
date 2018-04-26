using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a vertex class that has the vertex and the edges between other vertexes.

public class Vertex : MonoBehaviour {

	//Vertex will contain an edgelist and a method to make the connections.
	public List<Vertex> edgeList = new List<Vertex>();
	
	//Int to get the owners.
	public int nodeOwner = 0;

    public Vertex path;
    public bool KNOWN;
    public int dist;

	public void AddEdge(Vertex v)
    {
        edgeList.Add(v);
    }

}

