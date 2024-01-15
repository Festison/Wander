using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasGameManager;

public class FinManager : MonoBehaviour
{
    public GameObject FinObject;
    public GameObject logo;
    public Player_Controller_L player;

    void Start()
    {
        logo.SetActive(false);
        FinObject.SetActive(false);
    }

    void Update()
    {
        if (player.questid == 14)
        {
            FinObject.SetActive(true);
            logo.SetActive(true);
            CanvasGameManager.Instance.SetCurrentPage(mPageInfo.Fin);
        }
    }
}
