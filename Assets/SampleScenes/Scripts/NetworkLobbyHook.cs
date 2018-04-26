using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook 
{
    //lobideki oyuncu icin oyun sahnesi yuklenirken yapilacaklar
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        //GameManager.Instance.playerList.Add(gamePlayer); //lobideki oyuncuyu gameManager'deki oyuncularin listesine ekle

        //Oyuncunun sectigi rengi al
        //oyuncunun koydugu ismi al

    }
}
