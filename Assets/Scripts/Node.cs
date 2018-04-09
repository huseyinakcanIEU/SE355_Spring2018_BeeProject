using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eksik Ozellikler->
//-->>kontrol noktalarinda orumcek mi kus mu ne sakat bir sey varmis
//-->>isci ari resource node'a, soldier ari ise sadece controlNodelara gidebilirmis
//-->>oyunucun ari buradaysa (worker yani) kaynak uretim baz miktari arttir.(buff gibi) (aslinda isciler base'e git gel yaptikca daha mantikli olur,  varsa gonullu yapsin)


public class Node : MonoBehaviour
{
    public int concurentBee = 0; //how many bees in this node?
    NodeType nodeType; // enum type of node

    public string nodeOwner; //string degisebilir suan bilemedim
    public Color nodeSpriteColorOverlay; //p1 baskin ise mavi, p2 baskin ise kirmizi yap

    public NodeType NodeType1
    {
        get
        {
            return nodeType;
        }

        set
        {
            nodeType = value;
        }
    }

    public enum NodeType
    {
        Resource,
        Control,
    }

    private void Awake()
    {
        if (gameObject.CompareTag("ResourceNode"))
        {
            NodeType1 = NodeType.Resource;
        }
        else if (gameObject.CompareTag("ControlNode"))
        {
            NodeType1 = NodeType.Control;
        }
    }
}
