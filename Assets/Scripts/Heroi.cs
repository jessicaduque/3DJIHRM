using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroi : MonoBehaviour
{
    public float speed = 2.0f;
    public float sensibilidade;

    public float jumpForce = 5f;
    bool isGrounded = false;
    Rigidbody Rb;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Pular();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement -= Vector3.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        transform.position += movement.normalized * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }


    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rb.AddForce(Vector3.up * jumpForce);
        }
    }
}