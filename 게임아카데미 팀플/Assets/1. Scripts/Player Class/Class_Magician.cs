using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Class_Magician : PlayerClass
{
    public Player_Controller_L pc;
    [Header("마법사 스킬1")]
    public float skill1CoolTime = 2.0f;
    public GameObject lightningStrike;
    public bool isSkill1Cool;

    [Header("마법사 스킬2")]
    public float skill2CoolTime = 5.0f;
    public GameObject poisonArea;
    public bool isSkill2Cool;
    void Awake()
    {
        pc = transform.gameObject.GetComponent<Player_Controller_L>();
    }
    void Start()
    {
        lightningStrike = Resources.Load<GameObject>("3. Prefabs/Skill/LightningStrike");
        poisonArea = Resources.Load<GameObject>("3. Prefabs/Skill/Poison");
        isSkill1Cool = false;
        isSkill2Cool = false;
    }

    public override void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!isSkill1Cool)
            {
                pc.Mp -= pc.skill1CostMp;
                pc.mp.MyCurrentValue -= pc.skill1CostMp;
                SoundManager.instance.SFXplay("Thunder", pc.clip[3]);
                Instantiate(lightningStrike, gameObject.transform.position, Quaternion.identity);
                Instantiate(lightningStrike, transform.position + Vector3.left, Quaternion.identity);
                Instantiate(lightningStrike, gameObject.transform.position + Vector3.right, Quaternion.identity);
                Instantiate(lightningStrike, gameObject.transform.position + Vector3.up, Quaternion.identity);
                Instantiate(lightningStrike, gameObject.transform.position + Vector3.down, Quaternion.identity);
                Destroy(lightningStrike);
                isSkill1Cool = true;
                StartCoroutine(LightningStrikeco(skill1CoolTime));
            }
        }
    }

    public override void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isSkill2Cool)
            {
                pc.Mp -= pc.skill2CostMp;
                pc.mp.MyCurrentValue -= pc.skill2CostMp;
                SoundManager.instance.SFXplay("Poison", pc.clip[4]);
                Instantiate(poisonArea, gameObject.transform.position + Vector3.down * 2, Quaternion.identity);
                isSkill2Cool = true;
                StartCoroutine(PoisonAreaco(skill1CoolTime));
            }
        }
    }

    IEnumerator LightningStrikeco(float duration)
    {
        while (true)
        {
            if (isSkill1Cool == true)
            {
                yield return new WaitForSeconds(duration);
                isSkill1Cool = false;
            }
            yield return null;
        }
    }

    IEnumerator PoisonAreaco(float duration)
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
