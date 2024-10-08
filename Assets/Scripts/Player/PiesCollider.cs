using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesCollider : MonoBehaviour
{
    public bool isGrounded;
    private Animator animator;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            animator.SetBool("isFalling", false);
        } 
        else
        {
            animator.SetBool("isFalling", true);
        }
    }

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
