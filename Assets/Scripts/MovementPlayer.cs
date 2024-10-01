using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    
    public float speed = 10.0f;
    private Rigidbody rb;
    public float moverHorizontal;
    public float moverVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        moverVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(moverHorizontal, 0f, moverVertical);

        //if (movimiento.magnitude > 0f)
        //{
        //    // Normalizar el vector de movimiento y aplicar el movimiento
        //    transform.Translate(movimiento.normalized * speed * Time.fixedDeltaTime);
        //} 
        //else
        //{
        //    transform.Translate(Vector3.zero);
        //}

        if (movimiento.magnitude > 0f)
        {
            movimiento.Normalize();
        }
        else
        {
            movimiento = Vector3.zero; // Detener el movimiento
        }

        transform.Translate(movimiento.normalized * speed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        //transform.Translate(((new Vector3(moverHorizontal, 0f, moverVertical)).normalized) * speed * Time.deltaTime);
    }
}
