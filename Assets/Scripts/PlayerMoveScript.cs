using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private bool canJump;

    private void Start()
    {
        canJump = true;
    } 

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * Const.ROTSPEED;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * Const.MOVESPEED;

        if (canJump)
        {
            if (Input.GetButton("Jump"))
            {
                Debug.Log("jump!");
                GetComponent<Rigidbody>().AddForce(Vector3.up * Const.JUMPSPEED);
                canJump = false;
            }
        }
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            canJump = true;
        }
    }
}