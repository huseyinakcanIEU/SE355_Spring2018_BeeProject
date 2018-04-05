using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int concurentBee = 0;
    public string nodeType = null;



    enum NodeType
    {
        Resource,
        Control,
    }

    private void Awake()
    {
        if (gameObject.CompareTag("ResourceNode"))
        {
            nodeType = NodeType.Resource.ToString();
        }
        else if (gameObject.CompareTag("ControlNode"))
        {
            nodeType = NodeType.Control.ToString();
        }
    }
}
