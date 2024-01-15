using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Controller_L : MonoBehaviour
{
    [Header("플레이어 UI스텟")]
    public Stat hp;
    public Stat mp;
    public Stat stamina;
    public Stat exp;

    [Header("플레이어 스텟")]
    public int level;
    public float Max_Exp;
    public float Exp;
    public int Max_Hp;
    public int Hp;
    public int Max_MP;
    public int Mp;
    public int Max_Stmaina;
    public int Stamina;
    public int Str;
    public int Int;
    public int damage = 1;
    public float moveSpeed = 2f;
    public int skill1CostMp = 10;
    public int skill2CostMp = 30;
    public float dashSpeed;

    private Vector2 direction;
    Vector2 _vec;

    [Header("플레이어 상태 체크")]
    public bool IsConversation;
    private bool isAttack = false;
    public bool isDash;
    public bool isQuest;
    public bool IsQuest
    {
        get => isQuest;
        set
        {
            isQuest = value;
            nextQuest.SetActive(isQuest);
        }
    }

    bool isjobMagicion;
    [Header("플레이어 애니메이션")]
    public SpriteRenderer sprite;

    [Header("플레이어 컴포넌트")]
    public SPUM_Prefabs _prefabs;
    public player_Animator ani;
    public Collider2D weaponCol;
    public PlayerClass job;

    [Header("게임매니저")]
    public GameManager gameManager;
    public TalkManager talkManager;
    public QuestManager questManager;

    [Header("대화 텍스트")]
    public TextMeshProUGUI talkText;
    public GameObject conversationObject;
    public GameObject talkPanel;
    public Quest quest;
    public int talkIndex;

    [Header("퀘스트")]
    public int questIndex;
    public TextMeshProUGUI questText;
    public GameObject nextQuest;
    public QuestUI questUI;
    public int questid;

    [Header("레벨 텍스트")]
    public TextMeshProUGUI levelText;
    public string playerLevel;

    Rigidbody2D rigid;
    BoxCollider2D BoxCol;
    public GameObject mageAttack;
    private TrailRenderer dashEffect;

    public AudioClip[] clip;

    public Vector2 Dir
    {
        get
        {
            return rigid.velocity.normalized;
        }
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        conversationObject = GetComponent<GameObject>();
        ani = transform.GetChild(0).GetComponent<player_Animator>();
        job = GetComponent<PlayerClass>();
    }

    void Start()
    {
        _prefabs = GetComponent<SPUM_Prefabs>();
        dashEffect = GetComponent<TrailRenderer>();
        dashEffect.enabled = false;
        isjobMagicion = false;

        ShowUI();
        StartCoroutine(StaminUp());
        StartCoroutine(MpUp());
        StartCoroutine(evasion());               //회피 - 조수빈 0906
    }

    void Update()
    {
        if (!isjobMagicion)
        {
            if (TryGetComponent(out Class_Magician class_Magician)) isjobMagicion = true;
        }

        ani.AnimationSelect(1);
        Dash();

        if (!isDash)
        {
            Move();
        }

        Attack();
        Talk();
        GetInput();
        Skill();
        levelUP();
        ShowUI();
        HpLimit();
        Quest();       
    }

    //job이 가진 스킬
    void Skill()
    {
        if (Mp >= skill1CostMp)
        {
            job.Skill1();
        }
        if (Mp >= skill2CostMp)
        {
            job.Skill2();
        }
    }

    //레벨업
    void levelUP()
    {
        if (Exp >= Max_Exp)
        {
            Exp -= Max_Exp;
            level++;
            Max_Exp = level * 100;
            Max_Hp = level * 100;
            Hp = Max_Hp;
            Max_MP = level * 100;
            Mp = Max_MP;
            damage += 2;
            Str += 1;
            Int += 2;
        }
    }

    void HpLimit()
    {
        if (Hp > Max_Hp)
        {
            Hp = Max_Hp;
        }
    }

    void ShowUI()
    {
        hp.Initialize(Hp, Max_Hp);
        mp.Initialize(Mp, Max_MP);
        stamina.Initialize(Stamina, Max_Stmaina);
        exp.Initialize(Exp, Max_Exp);
        levelText.text = "Level : " + level.ToString();
    }

    //NPC대화
    void Talk()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsConversation == true)
        {
            talkPanel.SetActive(true);
            string talkData = talkManager.GetTalk(quest.talkid, talkIndex);
            talkText.text = talkData;
            talkIndex++;          
        }
    }

    void Quest()
    {
        if (IsQuest)
        {
            string questData = questManager.GetQuest(quest.questid, questIndex);
            questText.text = questData;
            questid = quest.questid;
        }
    }

    void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;
    }

    // 플레이어 이동
    void Move()
    {
        _vec = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _vec += Vector2.right;
            sprite.flipX = true;
            ani.AnimationSelect(2);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _vec += Vector2.left;
            sprite.flipX = false;
            ani.AnimationSelect(2);
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _vec += Vector2.up;
            ani.AnimationSelect(2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _vec += Vector2.down;
            ani.AnimationSelect(2);
        }
        rigid.velocity = _vec.normalized * moveSpeed;
    }
    //대쉬
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Stamina > 0)
        {
            stamina.MyCurrentValue -= 1;
            Stamina -= 1;
            isDash = true;
            rigid.velocity = rigid.velocity.normalized * dashSpeed;
            dashEffect.enabled = true;
        }
    }

    //평타 판정용 코드
    public bool IsAttack
    {
        get
        {
            return isAttack;
        }
        set
        {
            isAttack = value;
            weaponCol.enabled = isAttack;
        }
    }

    //검 공격 평타
    void Attack()
    {
        if (IsAttack)
            return;
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isjobMagicion && Dir != Vector2.zero)
            {
                if (Mp < 5)
                    return;
                Mp -= 5;
                mp.MyCurrentValue -= 5;
                SoundManager.instance.SFXplay("FireBall", clip[2]);
                GameObject slash = Instantiate(mageAttack, weaponCol.transform.position, Quaternion.identity);
                slash.transform.right = new Vector3(Dir.x, Dir.y, 0);
                slash.GetComponent<Rigidbody2D>().AddRelativeForce(Dir * 3, ForceMode2D.Impulse);
                Destroy(slash, 3);
            }
            IsAttack = true;
            Invoke("IsAttackOff", 0.2f);
            ani.AnimationSelect(3);
        }
    }

    void IsAttackOff()
    {
        IsAttack = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            IsConversation = true;
            conversationObject = collision.gameObject;
            quest = conversationObject.GetComponent<Quest>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            IsConversation = false;
            talkPanel.SetActive(false);
            talkIndex = 0;
            IsQuest = true;
        }
    }

    //스테미나 자동회복
    IEnumerator StaminUp()
    {
        while (true)
        {
            stamina.MyCurrentValue += 1;
            if (Stamina < Max_Stmaina)
            {

                Stamina += 1;

            }
            yield return new WaitForSeconds(3);
        }
    }
    //Mp 자동회복
    IEnumerator MpUp()
    {
        while (true)
        {
            mp.MyCurrentValue += 1;
            if (Mp < Max_MP)
            {

                Mp += 1;

            }
            yield return new WaitForSeconds(2);
        }
    }

    //대쉬 효과
    IEnumerator evasion()
    {
        while (true)
        {
            if (isDash)
            {
                yield return new WaitForSeconds(0.3f);
                isDash = false;
                dashEffect.enabled = false;
            }
            yield return null;
        }
    }
}
