using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private bool canJump;
    public GameObject staff;
    public GameObject player;

    private void Start()
    {
        canJump = true;
    } 

    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * Const.ROTSPEED;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * Const.MOVESPEED;

        if (Input.GetAxis("Vertical") != 0f)
        {
            Debug.Log("moving!");
            staff.GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            staff.GetComponent<Animator>().SetBool("Moving", false);
        }

        if (canJump)
        {
            if (Input.GetButton("Jump"))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * Const.JUMPSPEED);
                canJump = false;
            }
        }
        player.transform.Rotate(0, x, 0);
        player.transform.Translate(0, 0, z);
    }
}