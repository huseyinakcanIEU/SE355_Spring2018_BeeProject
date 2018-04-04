using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {
    [SerializeField]
    private int _soldierBeeNumber;
    [SerializeField]
    private int _workerBeeNumber;
    [SerializeField]
    private int _quota;

    public void SetQuota(int quota)
    {
        _quota = quota;
    }

    public int GetQuota()
    {
        return _quota;
    }

    public void SetSoldierBeeNumber(int soldier)
    {
            _soldierBeeNumber = soldier;
    }

    public void SetWorkerBeeNumber(int worker)
    {
            _workerBeeNumber = worker;
    }

    public int GetSoldierBeeNumber()
    {
        return _soldierBeeNumber;
    }

    public int GetWorkerBeeNumber()
    {
        return _workerBeeNumber;
    }
}
