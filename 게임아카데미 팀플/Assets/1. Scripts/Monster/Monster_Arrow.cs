using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Arrow : MonoBehaviour
{
    int atk;
    void Start()
    {
        //atk = GameObject.Find("Monster_Blackguard").transform.GetChild(0).GetComponent<Skeleton_ai>().atk;
        atk = FindObjectOfType<Skeleton_ai>().atk;
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player_Controller_L player = collision.GetComponent<Player_Controller_L>();
            player.Hp -= atk;
            player.hp.MyCurrentValue -= atk;
            Debug.Log("player Hp : " + player.Hp);
            Destroy(gameObject);
        }
    }
}
