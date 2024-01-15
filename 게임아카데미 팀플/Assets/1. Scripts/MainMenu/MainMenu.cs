using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Dim;
    public void OnClickNewGame()
    {
       
        Debug.Log(" 게임시작 ");
        SceneManager.LoadScene("GameIntro");
    }
    public void OnclickCancel()
    {
        Dim.SetActive(false);
    }
    public void OnclickQuitUI()
    {
        Dim.SetActive(true);
    }
    public void OnClickQuit()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}