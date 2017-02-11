using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject staff;
    private GameObject player;

    void Awake()
    {
        player = transform.GetChild(0).gameObject;
        staff = transform.Find("Player/Staff").gameObject;
    }

    void LateUpdate()
    {
        float rotateY = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Rigidbody rb = player.GetComponent<Rigidbody>();

        if (Input.GetAxis("Vertical") != 0)
        {
            staff.GetComponent<Animator>().SetBool("Moving", true);
            player.GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            staff.GetComponent<Animator>().SetBool("Moving", false);
            player.GetComponent<Animator>().SetBool("Moving", false);
        }

        if (player.GetComponent<PlayerCollision>().getCanJump() && Input.GetButton("Jump"))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * Const.JUMPSPEED);
            player.GetComponent<PlayerCollision>().canJumpFalse();
        }

        Vector3 rotationY = new Vector3(0f, rotateY, 0f);
        rotationY = rotationY.normalized * Const.ROTSPEED;
        Quaternion deltaRotation = Quaternion.Euler(rotationY);
        rb.MoveRotation(rb.rotation * deltaRotation);

        rb.MovePosition (rb.transform.position + rb.transform.forward * moveZ * Const.MOVESPEED);
        
    }
}
