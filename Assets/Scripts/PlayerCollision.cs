using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private bool canJump;
    private PlayerHealth ph;

    private void Start ()
    {
        ph = GetComponent<PlayerHealth>();
        canJump = true;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            canJump = true;
        }
       
    }

    void OnTriggerEnter(Collider collider)
    {
         if (collider.gameObject.tag.Equals("Bottom"))
        {
            Debug.Log("Fall");
            ph.AdjustCurHealth(-ph.curHealth);
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
