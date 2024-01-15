using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour
{
    public Player_Controller_L pc;
    public Transform pos;
    public GameObject mageAttack;

    void Update()
    {
        MageAtk();
    }
    void MageAtk()
    {
        if (Input.GetKeyUp(KeyCode.Alpha4) && pc.Dir != Vector2.zero)
        {
            pc.ani.AnimationSelect(3);
            GameObject slash = Instantiate(mageAttack, pos.position, Quaternion.identity);
            slash.transform.right = new Vector3(pc.Dir.x, pc.Dir.y, 0);
            slash.GetComponent<Rigidbody2D>().AddRelativeForce(pc.Dir * 3, ForceMode2D.Impulse);
            Destroy(slash, 3);
        }
    }
}
