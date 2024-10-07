using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerModel : MonoBehaviour
{
    CharacterController cc;

    public float speed = 10f; // Ajusta la velocidad aquí
    public Vector3 movimiento; // Vector de movimiento
    public Vector3 desplazamiento; // Vector de desplazamiento que incluirá la gravedad.
    public Animator animator;
    public float gravity = 9.81f; // Gravedad
    public float JumpForce = Mathf.Sqrt(2 * 9.81f * 2f); // Fuerza de salto
    public bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movimiento = new Vector3(horizontal, 0, vertical).normalized * speed;

        SetGravedad();
        Jump();

        // Combinar movimiento horizontal y gravedad
        desplazamiento.x = movimiento.x;
        desplazamiento.z = movimiento.z;


        // Mover càmara con el personaje
        CamDirecction(movimiento);



        // Mover el Character Controller
        cc.Move(desplazamiento * Time.deltaTime);

        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);

        

        AccionesVarias();
    }

    private void AccionesVarias()
    {
        Debug.Log(cc.isGrounded);
        if (!cc.isGrounded)
        {
            animator.SetBool("isJump", false);
        } 
        if (cc.isGrounded)
        {
            animator.SetBool("isJump", true);
        }


        if (Input.GetKey("f"))
        {
            animator.SetBool("Other", false);
            animator.Play("Muerte");
        }

        if (Input.GetKey("g"))  
        {
            animator.SetBool("Other", false);
            animator.Play("Perdida");
        }

        if (movimiento.x > 0 || movimiento.x < 0 || movimiento.y > 0 || movimiento.y < 0)
        {
            animator.SetBool("Other", true);
        }
        
    }

    private void CamDirecction(Vector3 movimiento)
    {
        if (movimiento != Vector3.zero) // Solo rotar si hay movimiento
        {
            // Calcular la rotación deseada
            Quaternion targetRotation = Quaternion.LookRotation(movimiento);
            // Rotar suavemente hacia la dirección del movimiento
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if (cc.isGrounded)
        {
            animator.SetBool("isJump", false);
           // desplazamiento.y = 0; // Resetear gravedad si está en el suelo

            if (Input.GetButton("Jump") && !isJump)
            {
                isJump = true;
                desplazamiento.y = JumpForce; //Mathf.Sqrt(2 * gravity * 2f);
                animator.Play("Jump");
            }
            else
            {
                isJump = false;
            }

        }
        else
        {
           
        }
    }

    private void SetGravedad()
    {
        desplazamiento.y -= gravity * Time.deltaTime; // Aplicar gravedad si no está en el suelo
    }
}
