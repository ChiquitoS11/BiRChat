using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    public float speed = 10f;
    public float JumpForce = 5f;
    public Vector3 movimiento;
    public bool saltar;
    public bool puedoSaltar;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);

        movimiento = new Vector3(horizontal, 0, vertical).normalized;

        saltar = Input.GetButtonDown("Jump") ? true : false;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimiento * speed * Time.fixedDeltaTime);

        if (saltar)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

    }

    //private void Cayendo()
    //{
    //    animator.SetBool("isFalling", true);
    //}

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene el tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // El personaje está en el suelo
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Cuando salimos del suelo, marcamos isGrounded como falso
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
