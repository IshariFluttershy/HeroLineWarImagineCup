using UnityEngine;
using System.Collections;

public class NetworkServer : MonoBehaviour {

    public Transform playerPrefab;
    public ArrayList playerScripts = new ArrayList();

    void OnServerInitialized()
    {
        SpawnPlayer(Network.player);
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        SpawnPlayer(player);
    }

    void SpawnPlayer(NetworkPlayer player)
    {
        string tempPlayerString = player.ToString();
        int playerNumber = int.Parse(tempPlayerString);

        Transform newPlayerTransform = (Transform)Network.Instantiate(playerPrefab, transform.position, transform.rotation, playerNumber);
        playerScripts.Add(newPlayerTransform.GetComponent("ProtoMovement"));
        NetworkView theNetworkView = newPlayerTransform.networkView;
        theNetworkView.RPC("SetPlayer", RPCMode.AllBuffered, player);
    }
}
