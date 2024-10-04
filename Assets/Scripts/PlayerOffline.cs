using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffline1 : MonoBehaviour
{
    CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {


        // Movimiento básico
        float moveSpeed = 5f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = (new Vector3(moveHorizontal, 0.0f, moveVertical)).normalized;

        cc.Move(movement * moveSpeed * Time.deltaTime);
    }
}
