using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class MovementPlayer : MonoBehaviourPunCallbacks
{
    CharacterController cc;
    private float gravity = 9.8f;
    private float speed = 5f;
    private float jumpForce = 5f;
    Vector3 movimiento;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movimiento = (new Vector3(moveHorizontal, 0.0f, moveVertical)).normalized;

            SetGravity();
            cc.Move(movimiento * speed * Time.deltaTime);
        }

        
    }

    public void SetGravity()
    {
        movimiento.y = -gravity * Time.deltaTime;
    }
}