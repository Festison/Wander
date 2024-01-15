using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasGameManager : MonoBehaviour
{
    private static CanvasGameManager instance;
    public static CanvasGameManager Instance
    {
        get
        {
            return instance;
        }
    }


    public enum mPageInfo
    {
        IdleUI,
        SubMenuUI,
        DieUI,
        QuestUI,
        Dimmed,
        Dimmed2,
        Fin
    }

    public GameObject IdleUI;
    public GameObject SubMenuUI;
    public GameObject DieUI;
    public GameObject QuestUI;
    public GameObject Dimmed;
    public GameObject Dimmed2;
    public GameObject Fin;

    [SerializeField]
    private bool isPause;
    public bool IsPause
    {
        get
        {
            return isPause;
        }
        set
        {
            isPause = value;
            if (isPause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    }

    private mPageInfo CurrentPageInfo;
    public int CurrentPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        IdleUI.SetActive(true);
    }

    public void SetCurrentPage(mPageInfo pageInfo)
    {
        CurrentPageInfo = pageInfo;
        CurrentPage = (int)CurrentPageInfo;

        SubMenuUI.SetActive(false);
        DieUI.SetActive(false);
        QuestUI.SetActive(false);
        Dimmed.SetActive(false);
        Dimmed2.SetActive(false);
        Fin.SetActive(false);

        if (CurrentPageInfo == mPageInfo.IdleUI)
        {
            IdleUI.SetActive(true);
        }
        else if (CurrentPageInfo == mPageInfo.SubMenuUI)
        {
            SubMenuUI.SetActive(true);
            Dimmed.SetActive(true);
        }
        else if (CurrentPageInfo == mPageInfo.DieUI)
        {
            DieUI.SetActive(true);
            Dimmed2.SetActive(true);
            StartCoroutine(GotoMainCo());
        }
        else if (CurrentPageInfo == mPageInfo.QuestUI)
        {
            QuestUI.SetActive(true);
            Dimmed.SetActive(true);
        }
        else if (CurrentPageInfo == mPageInfo.Fin)
        {
            Fin.SetActive(true);
            Dimmed.SetActive(true);
            StartCoroutine(GotoMainCo());
        }
    }
    IEnumerator GotoMainCo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenuScene");
    }
}
