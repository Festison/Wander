using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("대화 텍스트")]
    public TextMeshProUGUI talkText;
    public GameObject scanObject;

    public void Action()
    {
        talkText.text = "이것의 이름은" + scanObject.name + "이라고 한다.";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
