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

    void LateUpdate()
    {
        float rotateY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetAxis("Vertical") != 0)
        {
            staff.GetComponent<Animator>().SetBool("Moving", true);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            staff.GetComponent<Animator>().SetBool("Moving", false);
            GetComponent<Animator>().SetBool("Moving", false);
        }

        if (GetComponent<PlayerCollision>().getCanJump() && Input.GetButton("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Const.JUMPSPEED);
            GetComponent<PlayerCollision>().canJumpFalse();
        }

        Vector3 rotationY = new Vector3(0f, rotateY, 0f);
        rotationY = rotationY.normalized * Const.ROTSPEED;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        rb.MoveRotation(rb.rotation * deltaRotation);

        rb.MovePosition (rb.transform.position + rb.transform.forward * moveZ * Const.MOVESPEED);
        
    }
}
