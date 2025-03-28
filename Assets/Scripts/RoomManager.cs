using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;
     
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    [Space]
    public GameObject roomCam;

    void Awake(){
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting...");
        PhotonNetwork.ConnectUsingSettings();
        
    }
    public override void OnConnectedToMaster(){
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby(){
        base.OnJoinedLobby();
        PhotonNetwork.JoinOrCreateRoom("test", new Photon.Realtime.RoomOptions(), null); 
    }
    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        Debug.Log("We're connected and in a room now"); 
        roomCam.SetActive(false); 
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        // _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        //  _player.GetComponent<Health>().isLocalPlayer = true; 
    }
    public void RespawnPlayer(){
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        // _player.GetComponent<Health>().isLocalPlayer = true; 
    }

}
