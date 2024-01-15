using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour
{
    [Header("인트로 텍스트")]
    public TextMeshProUGUI introText;
    public int TextIndex = 0;
    public int TextId = 1;
    public GameObject loadingUI;

    Dictionary<int, string[]> IntroTextData;

    private void Awake()
    {
        loadingUI.SetActive(false);
        IntroTextData = new Dictionary<int, string[]>();
        IntroData();
    }

    void IntroData()
    {
        IntroTextData.Add(0, new string[] { "[아레니아 마을]의 레오니스는 사냥꾼이신 아버지에게서\r\n옆 마을에 의뢰한 물품을 찾아와 달라는 부탁을 받는다." });
        IntroTextData.Add(1, new string[] { "아버지가 말한 물품을 찾아 돌아온 레오니스는\r\n싸늘한 주검이 된 부모님을 마주하게 된다." });
        IntroTextData.Add(2, new string[] { "넋을 놓고 자리에 얼마나 머문지 모를 때 \r\n예전에 부모님과 일했다는 동료들이 레오니스를 찾아온다." });
        IntroTextData.Add(3, new string[] { "부모님을 죽인 진범을 찾을 수 있게 도와주겠다는 그들은\r\n자신들을 전사 [ 루카스 ]와 마법사 [ 아젤리아 ]라 소개했다." });
        IntroTextData.Add(4, new string[] { "혼자서는 아무것도 할 수 없다는 걸 통감한 레오니스는\r\n그들 중 한 명을 따라 복수를 위한 여정을 나선다." });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (TextId > 4)
            {
                loadingUI.SetActive(true);
                SceneManager.LoadScene("Wander");
            }
            string questData = GetIntro(TextId, TextIndex);
            introText.text = questData;
            TextId++;
        }
    }
    public string GetIntro(int textId, int textIndex)
    {
        return IntroTextData[textId][textIndex];
    }
    public void OnClickSkip()
    {
        Debug.Log("Skip");
        loadingUI.SetActive(true);
        SceneManager.LoadScene("Wander");
    }
}
