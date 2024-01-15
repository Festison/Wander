using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Spawn: MonoBehaviour
{
    public GameObject mob;
    public GameObject[] destroyMob;
    GameObject mobGroup;


    Vector3[] spawnPos = {  new Vector3(-28.8299999f,-130,0),
                            new Vector3(-10.2046146f,-143.246704f,0),
                            new Vector3(-21.324873f,-140.802704f,0),
                            new Vector3(-13.8706331f,-145.079727f,0),
                            new Vector3(-12.2209244f,-139.275192f,0),
                            new Vector3(-16.6201477f,-140.008392f,0),
                            new Vector3(-15.2148399f,-135.609177f,0),
                            new Vector3(-11.6710224f,-132.431961f,0),
                            new Vector3(-19.3696632f,-133.287354f,0),
                            new Vector3(-31.7700005f,-140.380005f,0),
                            new Vector3(-26.0906982f,-152.106262f,0),
                            new Vector3(-1.34506798f,-131.087753f,0),
                            new Vector3(-3.11697769f,-124.611115f,0),
                            new Vector3(-25.9073963f,-125.099915f,0),
                            new Vector3(-30.9176216f,-149.784439f,0)
                         };



    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {

            mobGroup = new GameObject("MobGroup");
            for(int i = 0; i < spawnPos.Length; i++) 
            {
               Instantiate(mob, spawnPos[i], Quaternion.identity).transform.parent = mobGroup.transform;

            }
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            Destroy(mobGroup);
            
        }

    }

}
