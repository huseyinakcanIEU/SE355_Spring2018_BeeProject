using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GraphManager : MonoBehaviour
{

	public List<Vertex> vertexList;


	// Use this for initialization
	void Start()
	{
		CreateGraph();
        Test(ShortestPath(vertexList[0], vertexList[12]));
	}

	//Create Graph.
	public void CreateGraph()
	{
		//Issiz gibi hepsini tek tek ekledim bana da programer demesinler :D::D :/
		vertexList[0].AddEdge(vertexList[1]);
		vertexList[1].AddEdge(vertexList[2]);
		vertexList[3].AddEdge(vertexList[4]);
		vertexList[4].AddEdge(vertexList[5]);
		vertexList[5].AddEdge(vertexList[6]);
		vertexList[6].AddEdge(vertexList[7]);
		vertexList[7].AddEdge(vertexList[8]);
		vertexList[8].AddEdge(vertexList[9]);
		vertexList[10].AddEdge(vertexList[11]);
		vertexList[11].AddEdge(vertexList[12]);
		vertexList[13].AddEdge(vertexList[0]);
		vertexList[13].AddEdge(vertexList[3]);
		vertexList[13].AddEdge(vertexList[10]);
		vertexList[14].AddEdge(vertexList[2]);
		vertexList[14].AddEdge(vertexList[9]);
		vertexList[14].AddEdge(vertexList[12]);

        vertexList[1].AddEdge(vertexList[0]);
        vertexList[2].AddEdge(vertexList[1]);
        vertexList[4].AddEdge(vertexList[3]);
        vertexList[5].AddEdge(vertexList[4]);
        vertexList[6].AddEdge(vertexList[5]);
        vertexList[7].AddEdge(vertexList[6]);
        vertexList[8].AddEdge(vertexList[7]);
        vertexList[9].AddEdge(vertexList[8]);
        vertexList[11].AddEdge(vertexList[10]);
        vertexList[12].AddEdge(vertexList[11]);
        vertexList[0].AddEdge(vertexList[13]);
        vertexList[3].AddEdge(vertexList[13]);
        vertexList[10].AddEdge(vertexList[13]);
        vertexList[2].AddEdge(vertexList[14]);
        vertexList[9].AddEdge(vertexList[14]);
        vertexList[12].AddEdge(vertexList[14]);
    }

    public void Test(List<Vertex> path)
    {
        for(int i = 0; i < path.Count; i++)
        {
            Debug.Log("Shortest path " + path[i].gameObject.name);
        }
    }

	//Shortest path alghoritm..
	public List<Vertex> ShortestPath(Vertex initialVertex, Vertex targetVertex)
	{
		//first create a new List that contains vertexes. Find the opponent and set the edges to INFINITY.
		//For player 1.
		List<Vertex> cloneVertexList = new List<Vertex>(vertexList);
        //cloneVertexList  = vertexList;
        //Erkin KURT
        Vertex source = cloneVertexList.Find(initialVertex.Equals); 

        Queue<Vertex> Q = new Queue<Vertex>();
        foreach (Vertex vertex in cloneVertexList)
        {
            vertex.KNOWN = false;
            vertex.dist = int.MaxValue;
        }

        source.dist = 0;
        Q.Enqueue(source);

        while (Q.Count > 0)
        {
            Vertex v = Q.Dequeue();
            foreach(Vertex w in v.edgeList)
            {
                if (w.nodeOwner != 2 || (w.nodeOwner == 2 && w == targetVertex))
                {
                    if (w.dist == int.MaxValue)
                    {
                        Debug.Log(v.gameObject.name);
                        w.dist = v.dist + 1;
                        w.path = v;
                        Q.Enqueue(w);
                    }
                }
            }
        }
        foreach (Vertex v in cloneVertexList)
        {
            Debug.Log("vertex " + v.name + " " + v.dist);

        }
        List<Vertex> path = new List<Vertex>();
        path.Add(targetVertex);
        Vertex tmp = cloneVertexList.Find(targetVertex.Equals);
        while (true)
        {
            Debug.Log(cloneVertexList.Find(tmp.Equals).gameObject.name);
            tmp = cloneVertexList.Find(tmp.Equals).path;
            path.Add(tmp);
            if (tmp == initialVertex)
                break;
        }
        path.Reverse();
        return path;
	}
}


