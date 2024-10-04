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
        networkPosition = transform.position; // Inicializa la posición de red
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            // Sincronización de la posición del jugador
            transform.position = Vector3.MoveTowards(transform.position, networkPosition, Time.deltaTime * 10);
            return;
        }

        float moveSpeed = 5f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = (new Vector3(moveHorizontal, 0.0f, moveVertical)).normalized;

        cc.Move(movement * moveSpeed * Time.deltaTime);

        // Actualiza la posición de red
        networkPosition = transform.position;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar la posición al otro jugador
            stream.SendNext(transform.position);
        }
        else
        {
            // Recibir la posición del otro jugador
            networkPosition = (Vector3)stream.ReceiveNext();
        }
    }
}