using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Class_Warrior : PlayerClass
{
    public Player_Controller_L pc;
    public Transform pos;
    [Header("전사 스킬1")]
    public float skill1CoolTime = 2.0f;
    public GameObject preFabSlash;
    public bool isSkill1Cool;

    [Header("전사 스킬2")]
    public float skill2CoolTime = 5.0f;
    public GameObject boom;
    public bool isSkill2Cool;

    void Awake()
    {
        pc = transform.gameObject.GetComponent<Player_Controller_L>();
        pos = FindObjectOfType<Sword_Trigger>().gameObject.transform;
    }
    void Start()
    {
        preFabSlash = Resources.Load<GameObject>("3. Prefabs/Skill/Slashright");
        boom = Resources.Load<GameObject>("3. Prefabs/Skill/Explosion");

        isSkill1Cool = false;
        isSkill2Cool = false;
    }
    // 검기 날리기
    public override void Skill1()
    {
        if (Input.GetKeyUp(KeyCode.A) && pc.Dir != Vector2.zero)
        {
            if (isSkill1Cool)
                return;
            pc.Mp -= pc.skill1CostMp;
            pc.mp.MyCurrentValue -= pc.skill1CostMp;
            pc.ani.AnimationSelect(3);
            SoundManager.instance.SFXplay("Slash", pc.clip[0]);
            GameObject slash = Instantiate(preFabSlash, pos.position, Quaternion.identity);
            slash.transform.right = new Vector3(pc.Dir.x, pc.Dir.y, 0);
            slash.GetComponent<Rigidbody2D>().AddRelativeForce(pc.Dir * 3, ForceMode2D.Impulse);
            Destroy(slash, 3);
            isSkill1Cool = true;
            StartCoroutine(Skill1Coolco(skill1CoolTime));
        }
    }
    // 지면 강타
    public override void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isSkill2Cool == false)
            {
                pc.Mp -= pc.skill2CostMp;
                pc.mp.MyCurrentValue -= pc.skill2CostMp;
                SoundManager.instance.SFXplay("Boom", pc.clip[1]);
                Instantiate(boom, gameObject.transform.position + Vector3.up, Quaternion.identity);
                isSkill2Cool = true;
                StartCoroutine(Skill2Coolco(skill2CoolTime));
            }
        }
    }
    IEnumerator Skill1Coolco(float duration)
    {
        while (true)
        {
            if (isSkill1Cool)
            {
                yield return new WaitForSeconds(duration);
                isSkill1Cool = false;
            }
            yield return null;
        }
    }

    IEnumerator Skill2Coolco(float duration)
    {
        while (true)
        {
            if (isSkill2Cool == true)
            {
                yield return new WaitForSeconds(duration);
                isSkill2Cool = false;
            }
            yield return null;
        }
    }
}
