using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NetworkManager : Photon.MonoBehaviour
{
    public GameObject player;
    private const string roomName = "KatkaDlyaTascheriv";
    private RoomInfo[] roomsList;
    private Vector3 vectorSpawn = new Vector3(8.0f, -2.3f, 0f);
    void Start()
    {
        DontDestroyOnLoad(this);
        PhotonNetwork.ConnectUsingSettings("0.11");
    }


    void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else if (PhotonNetwork.room == null)
        {

            // Create Room
           // if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                PhotonNetwork.CreateRoom(roomName, new RoomOptions() { IsVisible = true, IsOpen = true, maxPlayers = 4 }, TypedLobby.Default);
            //PhotonNetwork.JoinRandomRoom();

            // Join Room
            if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                   // if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
                        PhotonNetwork.JoinRoom(roomsList[i].name);
                }
            }
        }
    }

    void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
    }
    void OnJoinedRoom()
    {
      
        PhotonNetwork.Instantiate(player.name, vectorSpawn, Quaternion.identity, 0);
        Debug.Log("Connected to Room");
    }
   
}

