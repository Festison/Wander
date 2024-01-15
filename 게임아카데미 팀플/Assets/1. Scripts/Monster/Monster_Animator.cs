using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Animator : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void AnimationSelect(int i, float _attackState = 0)
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
                animator.SetFloat("NormalState", _attackState);
                break;
            case 4:
                animator.SetBool("Die", true);
                break;
            default:
                break;
        }
    }
}
