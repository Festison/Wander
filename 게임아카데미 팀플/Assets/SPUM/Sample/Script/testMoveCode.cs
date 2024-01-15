using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMoveCode : MonoBehaviour
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * 0.1f);
        }
    }
}
