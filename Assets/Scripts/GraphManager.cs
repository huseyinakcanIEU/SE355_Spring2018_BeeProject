using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{

	public List<Vertex> vertexList = new List<Vertex>();
	
	
	// Use this for initialization
	void Start () {
		CreateGraph();
	}
	//Create Graph.
	public void CreateGraph()
	{
		//Issiz gibi hepsini tek tek ekledim bana da programer demesinler :D::D :/
		vertexList[0].AddEdge(10,vertexList[1]);
		vertexList[1].AddEdge(10,vertexList[2]);
		vertexList[3].AddEdge(5,vertexList[4]);
		vertexList[4].AddEdge(5,vertexList[5]);
		vertexList[5].AddEdge(5,vertexList[6]);
		vertexList[6].AddEdge(5,vertexList[7]);
		vertexList[7].AddEdge(5,vertexList[8]);
		vertexList[8].AddEdge(5,vertexList[9]);
		vertexList[10].AddEdge(10,vertexList[11]);
		vertexList[11].AddEdge(10,vertexList[12]);
		vertexList[13].AddEdge(10,vertexList[0]);
		vertexList[13].AddEdge(10,vertexList[3]);
		vertexList[13].AddEdge(10,vertexList[10]);
		vertexList[14].AddEdge(10,vertexList[2]);
		vertexList[14].AddEdge(10,vertexList[9]);
		vertexList[14].AddEdge(10,vertexList[12]);
		
	}
}


