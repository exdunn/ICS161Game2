using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject staff;

    void Awake()
    {
        staff = transform.Find("Staff").gameObject;
    }

    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Rotation Axis");
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 move = new Vector3(moveX, 0, moveZ);
        // movement based on WASD
  
            rb.MovePosition(rb.transform.position + move * Const.MOVESPEED);
            //rb.MovePosition(rb.transform.position + rb.transform.forward * moveZ * Const.MOVESPEED);

        if (rotation != 0)
        {
            Vector3 rotationY = new Vector3(0f, rotation, 0f);
            rotationY = rotationY * Const.ROTSPEED;
            Quaternion deltaRotation = Quaternion.Euler(rotationY);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        /*if (Input.GetAxis("Vertical") != 0)
        {
            staff.GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            staff.GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Moving", false);
        }*/

        if (GetComponent<PlayerCollision>().getCanJump() && Input.GetButton("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Const.JUMPSPEED);
            GetComponent<PlayerCollision>().canJumpFalse();
        }
    }
}
