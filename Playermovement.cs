using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float jumpspeed;
    public float movementSpeed;
    private Rigidbody player;
    private bool onground = true;
    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onground)
        {
            player.AddForce(Vector3.up * jumpspeed, ForceMode.VelocityChange);
            onground = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        onground = true;
    }
}
