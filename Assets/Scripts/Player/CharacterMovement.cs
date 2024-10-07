using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController cc;
    private float speed = 10f; // Ajusta la velocidad aquí
    private float gravity = 9.81f; // Gravedad
    private Vector3 desplazamiento; // Vector de desplazamiento que incluirá la gravedad.
    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear el vector de movimiento y normalizarlo
        Vector3 movimiento = new Vector3(horizontal, 0, vertical).normalized * speed;

        SetGravedad();
        Jump();

        // Combinar movimiento horizontal y gravedad
        desplazamiento.x = movimiento.x;
        desplazamiento.z = movimiento.z;

        // Mover el Character Controller
        cc.Move(desplazamiento * Time.deltaTime);
    }

    private void Jump()
    {
        if (cc.isGrounded)
        {
            if (Input.GetKey("space") && !isJump)
            {
                isJump = true;
                desplazamiento.y = Mathf.Sqrt(2 * gravity * 2f);
            } 
            else
            {
                isJump = false;
            }

        }
    }

    private void SetGravedad()
    {
        desplazamiento.y -= gravity * Time.deltaTime; // Aplicar gravedad si no está en el suelo
    }
}
