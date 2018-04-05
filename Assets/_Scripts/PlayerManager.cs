using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject base_P1;
    public GameObject base_P2;

    private void Awake()
    {
        //init player1 & player2 base
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");
    }

   

}
