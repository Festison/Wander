using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Spawn : MonoBehaviour
{
    public GameObject mob;
    public GameObject[] destroyMob;
    GameObject mobGroup;


    Vector3[] spawnPos = {  new Vector3(38.8082962f,-204.211761f,0),
                            new Vector3(48.5099983f,-206.5f,0),
                            new Vector3(56.0499992f,-215.860001f,0),
                            new Vector3(62.4186554f,-203.891617f,0),
                            new Vector3(66.9006195f,-206.932953f,0),
                            new Vector3(55.8557739f,-209.173935f,0),
                            new Vector3(49.4529648f,-194.847656f,0),
                            new Vector3(44.8109283f,-200.290039f,0),
                            new Vector3(37.9279099f,-186.684067f,0),
                            new Vector3(45.2911377f,-185.483536f,0),
                            new Vector3(42.7300148f,-188.204742f,0),
                            new Vector3(48.1724014f,-215.336639f,0),
                            new Vector3(55.3755646f,-188.604904f,0),
                            new Vector3(63.4591103f,-216.457123f,0),
                            new Vector3(40.6500015f,-208.929993f,0)
                         };



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            mobGroup = new GameObject("MobGroup");
            for (int i = 0; i < spawnPos.Length; i++)
            {
                Instantiate(mob, spawnPos[i], Quaternion.identity).transform.parent = mobGroup.transform;

            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(mobGroup);

        }

    }

}
