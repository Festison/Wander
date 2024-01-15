using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CanvasGameManager;

public class SubMenu : MonoBehaviour
{
    public GameObject SubMenuUI;
    private void Start()
    {
        SubMenuUI.SetActive(false);
    }
    void Update()
    {
        // 일시정지 구현
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanvasGameManager.Instance.IsPause == false)
            {
                OnClickSubUI();
            }
            else if (CanvasGameManager.Instance.IsPause == true)
            {
                OnclickCancel();
            }
        }
    }

    public void OnClickSubUI()
    {
        CanvasGameManager.Instance.IsPause = true;
        CanvasGameManager.Instance.SetCurrentPage(mPageInfo.SubMenuUI);
    }
    public void OnclickCancel()
    {
        CanvasGameManager.Instance.IsPause = false;
        CanvasGameManager.Instance.SetCurrentPage(mPageInfo.IdleUI);
    }
    public void OnClickQuit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
