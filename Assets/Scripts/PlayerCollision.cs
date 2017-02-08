using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private bool canJump;

    private void Start ()
    {
        canJump = true;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            Debug.Log("TEST");
            canJump = true;
        }
    }

    public void canJumpFalse ()
    {
        canJump = false;
    }

    public bool getCanJump ()
    {
        return canJump;
    }
}
