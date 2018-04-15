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
    }

    #endregion

    //Game rule values
    public int soldierBeeResourceCost;
    public int workerBeeResourceCost;

    public int soldierBeeQuotaCost;
    public int workerBeeQuotaCost;

    public int maxBeeQuota;

    //Base node kac Bee ile baslayacak?
    public int soldierBeeStartValue;
    public int workerBeeStartValue;

}
