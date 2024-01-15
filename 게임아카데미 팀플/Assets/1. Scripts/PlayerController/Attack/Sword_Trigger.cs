using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Trigger : MonoBehaviour
{
    public Player_Controller_L pState = null;
    BoxCollider2D boxCol = null;

    void Start()
    {
        pState = transform.root.GetComponent<Player_Controller_L>();
        boxCol = GetComponent<BoxCollider2D>();
        pState.weaponCol = boxCol;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (pState.isAttack)
        {
            boxCol.enabled = true;
        }
        else
        {
            boxCol.enabled = false;
        }
    }
    */
}
