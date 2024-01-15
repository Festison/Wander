using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Weapon : MonoBehaviour
{
    Skeleton_ai state;
    Monster_State state2;
    int atk;
    Collider2D col;
    void Awake()
    {
        state = transform.root.GetChild(0).GetComponent<Skeleton_ai>();
        state2 = transform.root.GetChild(0).GetComponent<Monster_State>();
        atk = transform.root.GetChild(0).GetComponent<Skeleton_ai>().atk;
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player_Controller_L player = collision.GetComponent<Player_Controller_L>();
            player.Hp -= atk;
            player.hp.MyCurrentValue -= atk;
            Debug.Log("PlayerHp : " + player.Hp);
            col.enabled = false;
        }
    }
}
