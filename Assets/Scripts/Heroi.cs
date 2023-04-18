using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroi : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 5f;

    bool isGrounded = false;

    Rigidbody Rb;
    public Transform cam;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Pular();
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        float horInput = Input.GetAxisRaw("Horizontal") * speed;
        float verInput = Input.GetAxisRaw("Vertical") * speed;

        //camera dir
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        //creating relate cam direction
        Vector3 forwardRelative = verInput * camForward;
        Vector3 RightRelative = horInput * camRight;

        Vector3 moveDir = forwardRelative + RightRelative;

        //movement

        Rb.velocity = new Vector3(moveDir.x, Rb.velocity.y, moveDir.z);

        //if (Input.GetButtonDown("Jump") && Mathf.Approximately(Rb.velocity.y, 0)) Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);

        transform.forward = new Vector3(Rb.velocity.x, 0f, Rb.velocity.z);

    }


    /*void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rb.AddForce(Vector3.up jumpForce);
        }
    }
    */
}