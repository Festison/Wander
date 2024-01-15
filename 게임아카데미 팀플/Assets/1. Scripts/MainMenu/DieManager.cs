using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CanvasGameManager;

public class DieManager : MonoBehaviour
{
    public GameObject DieObject;
    Player_Controller_L playerState;
    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playerState = FindObjectOfType<Player_Controller_L>();
        isDead = false;
        DieObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState.Hp <= 0 && !isDead)
        {
            if (CanvasGameManager.Instance.IsPause == false)
            {
                isDead = true;
                DieObject.SetActive(true);
                CanvasGameManager.Instance.SetCurrentPage(mPageInfo.DieUI);
            }
        }
    }
}
