using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skeleton_ai : Monster_State
{
    public GameObject parentObj;
    Player_Controller_L player;

    public Collider2D monsterWeaponCol;
    Vector2 setPosition;                //Player따라가기 전 위치
    public Transform target;            //Player인식
    public bool isAttackCool;           //공격 쿨타임중

    public Monster_Radar radar;         //UnitRoot에 있는 Collider2D
    public Rigidbody2D targetrigid;     //추적할 Player_Rigidbody2D
    Monster_Animator animator;
    Rigidbody2D rigid;
    Vector2 defaultPosition;

    public GameObject arrow;            //공격할 투사체
    Camera cam;

    public GameObject Item;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player_Controller_L>();
        parentObj = transform.root.gameObject;
        rigid = GetComponent<Rigidbody2D>();
        radar = transform.GetChild(0).GetComponent<Monster_Radar>();
        animator = transform.GetChild(0).GetComponent<Monster_Animator>();

        cam = Camera.main;
    }
    void Start()
    {
        isLive = true;
        isAttackCool = false;
        monsterWeaponCol.enabled = false;
        defaultPosition = transform.position;
        setPosition = defaultPosition;
        bgHpbar.SetActive(false);
        Hpbar.fillAmount = 1;
    }

    void Update()
    {
        bgHpbar.transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        animator.AnimationSelect(1);
        if (isLive)
        {
            targetrigid = radar.targetRigid;
            if (targetrigid != null)
            {
                if (Vector2.Distance(targetrigid.position, rigid.position) <= attackRange)
                {
                    rigid.velocity = Vector2.zero;
                    Attack();
                }
                else
                {
                    if (setPosition == defaultPosition)
                    {
                        setPosition = transform.position;
                    }
                    Move(targetrigid.position);
                }
            }
            else
            {
                if (Vector2.Distance(rigid.position, setPosition) >= attackRange)
                {
                    Move(setPosition);
                }
                else
                {
                    setPosition = defaultPosition;
                    rigid.position = defaultPosition;
                    animator.AnimationSelect(1);
                }
            }
            //agent.setdestination(target.position);
            //TargetToRange();
        }
    }
    void Move(Vector2 _position)
    {
        if (isAttackCool)
            return;
        if (_position.x > rigid.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
            //_position += new Vector2(-1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            //_position += new Vector2(1, 0);
        }
        Vector2 dirVec = _position - rigid.position;
        Vector2 nextVec = dirVec.normalized * moveSpeed;
        transform.Translate(nextVec * Time.deltaTime);
        animator.AnimationSelect(2);
        //rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;

    }
    void Attack()
    {
        if (isAttackCool)
            return;
        monsterWeaponCol.enabled = true;
        Invoke("AttackCool", 0.2f);
        animator.AnimationSelect(3, attackState);
        StartCoroutine(AttackCoolco());
        if (attackState != 0)
        {
            Shoot();
        }
    }
    void AttackCool()
    {
        monsterWeaponCol.enabled = false;
    }
    IEnumerator AttackCoolco()
    {
        isAttackCool = true;
        yield return new WaitForSeconds(attackSpeed);
        isAttackCool = false;
    }
    void Shoot()
    {
        Vector2 dir = targetrigid.transform.position - rigid.transform.position;
        GameObject monsterArrow = Instantiate(arrow);
        monsterArrow.transform.right = new Vector2(dir.x, dir.y);
        monsterArrow.transform.position = monsterWeaponCol.transform.position;
        monsterArrow.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 3.0f, ForceMode2D.Impulse);
    }
    protected override void Die()
    {
        if (!isLive)
            return;
        isLive = false;
        rigid.velocity = Vector2.zero;
        animator.AnimationSelect(4);
        player.Exp += exp;
        player.exp.MyCurrentValue += exp;
        Destroy(parentObj, 1.0f);

        ItemProbability();
    }
    void ItemProbability()
    {
        int random = Random.Range(0, 10);
        if (random <= 2)
        {
            GameObject spawnItem = Instantiate(Item);
            spawnItem.transform.position = transform.position;
        }
    }

    public override void GetDamage(int _damage)
    {
        base.GetDamage(_damage);

        Hpbar.fillAmount = (float)hp / maxHp;
        bgHpbar.SetActive(true);
    }
}
