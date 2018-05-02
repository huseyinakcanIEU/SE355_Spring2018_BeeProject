using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NumberSyncTest : NetworkBehaviour
{
    [SyncVar]
    public int myNumber = 0;

    public void IncrementMyNumberFromServer()
    {
        if (!isServer)
        {
            return;
        }
        myNumber++;
        Debug.Log("Server: I'm incremented myNumber >>> " + myNumber);
    }

}
