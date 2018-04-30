using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NumberSyncTest : NetworkBehaviour
{
    [SyncVar(hook = "IncrementSyncCallBack")]
    public int testNumber = 0;


    public void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            IncrementSyncCallBack(1);
        }

        Debug.Log("TestNumber " + testNumber);
    }

    //[Command]
    public void IncrementSyncCallBack(int newNumber)
    {
        if (isServer)
        {
            return;
        }
        testNumber = testNumber + newNumber;
    }
}
