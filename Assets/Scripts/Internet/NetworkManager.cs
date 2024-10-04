using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Conectar al servidor de Photon
    }

    /// <summary>
    /// esta funci�n se llama cuando se conecta al servidor de Photon (es llamado automaticamente por el metodo ConnectUsingSettings)
    /// </summary>
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al Master Server");
        CreateOrJoinRoom();
    }

    /// <summary>
    /// esta funci�n ser llama cuando falla la conexi�n al servidor de Photon (es llamado automaticamente por el metodo ConnectUsingSettings)
    /// </summary>  
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Error al unirse a la sala: " + message);
    }

    public void CreateOrJoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions(); // instanciar una sala
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom("RoomName", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);

        // posici�n del jugador
        Vector3 spawnPosition = new Vector3(0, 1.5f, 0); // punto de aparici�n del jugador
        Quaternion spawnOrientacion = Quaternion.identity; // la orientacion donde mira el jugador (inicia mirando a donde mira el mu�eco de unity)

        // instanciar al jugador
        PhotonNetwork.Instantiate("Character", spawnPosition, spawnOrientacion, 0);
    }
}
