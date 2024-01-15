using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stat : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private TextMeshProUGUI statText;

    private float currentFill;
    public float MyMaxValue { get; set; }

    // 체력과 만의 현재 값 설정
    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)
            {
                MyCurrentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            statText.text = currentValue + " / " + MyMaxValue;
            currentFill = currentValue / MyMaxValue;
        }
    }

    private void Start()
    {
        content = GetComponent<Image>();
    }

    private void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
