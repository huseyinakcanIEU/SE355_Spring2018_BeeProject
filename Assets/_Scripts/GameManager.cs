using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton GameManager

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GameManager");
                gm.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this; //singleton

        //init player base
        base_P1 = GameObject.FindGameObjectWithTag("BaseP1");
        base_P2 = GameObject.FindGameObjectWithTag("BaseP2");
    }

    #endregion

    public GameObject base_P1;
    public GameObject base_P2;

}
