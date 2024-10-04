using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovementPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    CharacterController cc;
    private Vector3 networkPosition;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        networkPosition = transform.position; // Inicializa la posici�n de red
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // Sincronizaci�n de la posici�n del jugador
            transform.position = Vector3.MoveTowards(transform.position, networkPosition, Time.deltaTime * 10);
            return;
        }

        float moveSpeed = 5f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = (new Vector3(moveHorizontal, 0.0f, moveVertical)).normalized;

        cc.Move(movement * moveSpeed * Time.deltaTime);

        // Actualiza la posici�n de red
        networkPosition = transform.position;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar la posici�n al otro jugador
            stream.SendNext(transform.position);
        }
        else
        {
            // Recibir la posici�n del otro jugador
            networkPosition = (Vector3)stream.ReceiveNext();
        }
    }
}