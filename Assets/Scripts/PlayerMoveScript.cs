using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private GameObject staff;
    private GameObject player;

    void Awake ()
    {

        player = transform.GetChild(0).gameObject;
        staff = transform.Find("Player/Staff").gameObject;
    }

    void FixedUpdate()
    {
        var x = Input.GetAxis ("Horizontal") * Time.deltaTime * Const.ROTSPEED;
        var z = Input.GetAxis ("Vertical") * Time.deltaTime * Const.MOVESPEED;

        if (Input.GetAxis("Vertical") != 0f)
        {
            staff.GetComponent<Animator> ().SetBool ("Moving", true);
            player.GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            staff.GetComponent<Animator> ().SetBool ("Moving", false);
            player.GetComponent<Animator> ().SetBool("Moving", false);
        }
        /*if(Input.GetAxis("Horizontal") != 0f)
        {
            player.GetComponent<Animator>().applyRootMotion = true;
        }
        else
        {
            player.GetComponent<Animator>().applyRootMotion = false;
        }*/

        if (player.GetComponent<PlayerCollision> ().getCanJump ())
        {
            if (Input.GetButton ("Jump"))
            {
                player.GetComponent<Rigidbody> ().AddForce (Vector3.up * Const.JUMPSPEED);
                player.GetComponent<PlayerCollision> ().canJumpFalse ();
            }
        }
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}