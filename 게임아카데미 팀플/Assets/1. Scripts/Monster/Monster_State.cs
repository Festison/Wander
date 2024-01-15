using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_State : MonoBehaviour
{
    public enum Battle_Type
    {
        rock,
        scissors,
        paper
    }

    public Battle_Type battleType;      //monsterŸ��
    public Battle_Type attackType;      //player ����Ÿ��
    float trueDamage;                 //monster�� ������ �޴� damage

    public int maxHp;
    public int hp;
    public int atk;
    public int exp;
    public float moveSpeed;             //�̵��ӵ�
    public float attackRange;           //�����Ÿ�
    public float attackSpeed;           //���ݼӵ�
    public bool isLive = true;

    public float attackState;           //���ݸ��

    public GameObject bgHpbar;
    public Image Hpbar;

    public Player_Controller_L playerState;


    public virtual void GetDamage(int _damage)
    {

        DamageControl(_damage);
        hp -= (int)trueDamage;
        if (hp <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        isLive = false;
        Debug.Log(gameObject.name + "DIE");
    }
    //Player_Controller_Lã��
    void FindPlayer()
    {
        if (playerState == null)
            playerState = GameObject.Find("Player").GetComponent<Player_Controller_L>();
        else
            return;
    }

    //monster�� �޴� ����� ����
    void DamageControl(int _damage)
    {
        if (battleType == attackType)
        {
            trueDamage = _damage;
        }
        else if (battleType == Battle_Type.rock)
        {
            switch (attackType)
            {
                case Battle_Type.scissors:
                    trueDamage = _damage * 0.5f;
                    break;
                case Battle_Type.paper:
                    trueDamage = _damage * 1.5f;
                    break;
            }
        }
        else if (battleType == Battle_Type.scissors)
        {
            switch (attackType)
            {
                case Battle_Type.rock:
                    trueDamage = _damage * 1.5f;
                    break;
                case Battle_Type.paper:
                    trueDamage = _damage * 0.5f;
                    break;
            }
        }
        else if (battleType == Battle_Type.paper)
        {
            switch (attackType)
            {
                case Battle_Type.scissors:
                    trueDamage = _damage * 1.5f;
                    break;
                case Battle_Type.rock:
                    trueDamage = _damage * 0.5f;
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �⺻ ����  - Ÿ�� X
        if (collision.tag == "Weapon")
        {
            FindPlayer();
            collision.GetComponent<Sword_Trigger>().pState.IsAttack = false;
            GetDamage(playerState.damage + playerState.Str);
        }

        // �⺻ ����  - Ÿ�� X
        if (collision.tag == "MageAttack")
        {
            FindPlayer();
            GetDamage(playerState.damage);
        }

        // �߻���  - Ÿ�� : ���� Ÿ��
        if (collision.tag == "WarriorSkill1")
        {
            FindPlayer();
            attackType = Battle_Type.scissors;
            GetDamage(playerState.damage + playerState.Str);
        }

        // ������  - Ÿ�� : �ָ� Ÿ��
        if (collision.tag == "WarriorSkill2")
        {
            FindPlayer();
            attackType = Battle_Type.rock;
            GetDamage(playerState.damage + playerState.Str);
        }

        // ������  - Ÿ�� : �ָ� Ÿ��
        if (collision.tag == "MageSkill1")
        {
            FindPlayer();
            attackType = Battle_Type.rock;
            GetDamage(playerState.damage + playerState.Int);
        }

        // ��ġ��  - Ÿ��  : ���ڱ� Ÿ��
        if (collision.tag == "MageSkill2")
        {
            FindPlayer();
            attackType = Battle_Type.paper;
            GetDamage(playerState.damage + playerState.Int);
        }

    }
}
