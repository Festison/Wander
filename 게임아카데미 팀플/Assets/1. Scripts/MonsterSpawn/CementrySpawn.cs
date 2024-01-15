using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CementrySpawn : MonoBehaviour
{
    public GameObject mob;
    public GameObject[] destroyMob;
    GameObject mobGroup;


    Vector3[] spawnPos = {  new Vector3(129.886536f,78.138092f,-0.0716495886f),
                            new Vector3(136.214905f,87.4930725f,-0.0716495886f),
                            new Vector3(143.162354f,86.6676331f,-0.0716495886f),
                            new Vector3(141.786621f,79.5138245f,-0.0716495886f),
                            new Vector3(154.787292f,90.7948303f,-0.0716495886f),
                            new Vector3(135.320679f,93.5462952f,-0.0716495886f),
                            new Vector3(131.468628f,89.9693909f,-0.0716495886f),
                            new Vector3(131.950134f,85.3606873f,-0.0716495886f),
                            new Vector3(141.098755f,91.3451233f,-0.0716495886f),
                            new Vector3(153.273987f,97.3983383f,-0.0716495886f),
                            new Vector3(148.046204f,99.8746567f,-0.0716495886f),
                            new Vector3(152.79248f,84.1225281f,-0.0716495886f),
                            new Vector3(133.807373f,99.5995102f,-0.0716495886f),
                            new Vector3(137.475998f,78.138092f,-0.0716495886f),
                            new Vector3(141.947128f,98.361351f,-0.0716495886f)
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
