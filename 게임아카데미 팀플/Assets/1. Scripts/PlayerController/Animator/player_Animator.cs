using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Animator : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimationSelect(int i)
    {
        switch (i)
        {
            case 1:
                animator.SetFloat("RunState", 0);
                break;
            case 2:
                animator.SetFloat("RunState", 0.5f);
                break;
            case 3:
                animator.SetBool("Attack", true);
                break;
            case 4:
                animator.SetTrigger("death");
                break;
            default:
                break;
        }
    }

}
