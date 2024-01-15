using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Radar : MonoBehaviour
{
    public Rigidbody2D targetRigid;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            targetRigid = collision.GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            targetRigid = null;
    }

}
