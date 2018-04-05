using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int concurentBee = 0;
    NodeType nodeType; // enum type of node

    public string nodeOwner; //string degisebilir suan bilemedim


    enum NodeType
    {
        Resource,
        Control,
    }

    private void Awake()
    {
        if (gameObject.CompareTag("ResourceNode"))
        {
            nodeType = NodeType.Resource;
        }
        else if (gameObject.CompareTag("ControlNode"))
        {
            nodeType = NodeType.Control;
        }
    }
}
