using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Posion : MonoBehaviour
{
    public int hpHeal = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.transform.GetComponent<Player_Controller_L>().Hp += hpHeal;
            Destroy(gameObject);
        }
    }
}
