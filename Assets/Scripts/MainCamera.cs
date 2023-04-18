using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform Player;
    public float MouseSpeed = 3;
    public float orbitDamping = 10;

    Vector3 localRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        transform.position = Player.position;

        localRotation.x += Input.GetAxis("Mouse X") * MouseSpeed;
        //localRotation.y -= Input.GetAxis("Mouse Y") * MouseSpeed;

        localRotation.y = Mathf.Clamp(localRotation.y, 0f, 80f);


        //Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0f);
        Quaternion QT = Quaternion.Euler(0f, localRotation.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
    
    
    }
}