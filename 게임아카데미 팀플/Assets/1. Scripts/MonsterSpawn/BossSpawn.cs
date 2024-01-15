using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject mob;
    public GameObject[] destroyMob;
    GameObject mobGroup;


    Vector3[] spawnPos = {  new Vector3(54.8255692f,-157.01712f,0),
                            new Vector3(47.9220581f,-151.839478f,0),
                            new Vector3(59.7443237f,-150.458771f,0),
                            new Vector3(63.9727249f,-134.839584f,0),
                            new Vector3(58.0184441f,-142.864914f,0),
                            new Vector3(53.2722816f,-147.179611f,0),
                            new Vector3(46.5413551f,-144.331909f,0),
                            new Vector3(53.876339f,-137.342102f,0),
                            new Vector3(57.9321518f,-132.078171f,0),
                            new Vector3(63.9727249f,-127.245712f,0),
                            new Vector3(57.2417984f,-124.829483f,0),
                            new Vector3(53.1859856f,-119.479263f,0),
                            new Vector3(50.6834641f,-123.707664f,0),
                            new Vector3(53.7037506f,-128.540131f,0),
                            new Vector3(44.6428909f,-121.291435f,0)
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
