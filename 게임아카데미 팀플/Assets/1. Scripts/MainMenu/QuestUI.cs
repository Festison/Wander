using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasGameManager;

public class QuestUI : MonoBehaviour
{
    [Header("Äù½ºÆ® Äµ¹ö½º")]
    public GameObject QuestObject;
    public bool IsPause;

    private void Start()
    {
        IsPause = false;
        QuestObject.SetActive(false);
    }

    void Update()
    {
        if (!gameObject)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!IsPause)
            {
                Time.timeScale = 0;
                IsPause = true;
                CanvasGameManager.Instance.SetCurrentPage(mPageInfo.QuestUI);
                FindObjectOfType<Player_Controller_L>().IsQuest = false;
            }
            else if (IsPause)
            {
                Time.timeScale = 1;
                IsPause = false;
                CanvasGameManager.Instance.SetCurrentPage(mPageInfo.IdleUI);
            }

        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Time.timeScale = 1;
                IsPause = false;
                CanvasGameManager.Instance.SetCurrentPage(mPageInfo.IdleUI);
            }
        }      
    }

    public void OnClickQuestUI()
    {
        Time.timeScale = 0;
        IsPause = true;
        CanvasGameManager.Instance.SetCurrentPage(mPageInfo.QuestUI);
        FindObjectOfType<Player_Controller_L>().IsQuest = false;
    }

    public void OnclickCancel()
    {
        Time.timeScale = 1;
        IsPause = false;
        CanvasGameManager.Instance.SetCurrentPage(mPageInfo.IdleUI);
    }
}
