using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject staff;
    private Vector3 middleOfScreen;

    void Awake()
    {
        middleOfScreen = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        staff = transform.Find("Staff").gameObject;
    }

    void Update()
    {
        float moveY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Rigidbody rb = GetComponent<Rigidbody>();

        // movement based on WASD
        if (moveY != 0)
        {
            rb.MovePosition(rb.transform.position + rb.transform.right * moveY * Const.MOVESPEED);
        }
        if (moveZ != 0)
        {
            rb.MovePosition(rb.transform.position + rb.transform.forward * moveZ * Const.MOVESPEED);
        }

        // mouse rotation
        Vector3 camVec = Input.mousePosition - middleOfScreen;
        Vector3 flipped = new Vector3(camVec.x, 0f, camVec.y);
        transform.LookAt(flipped);

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
