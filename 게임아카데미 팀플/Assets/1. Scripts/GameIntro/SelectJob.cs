using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectJob : MonoBehaviour
{
    public GameObject player;
    public GameObject Dim;
    public GameObject JobButton;
    public Image image;
    public Texture2D warriorCursor;
    public Texture2D mageCursor;

    public Sprite[] weaponImage;
    public SpriteRenderer weaponRender;

    private void Start()
    {
        Time.timeScale = 0;
        JobButton.SetActive(true);
        Dim.SetActive(true);
        player = GameObject.Find("Player");
        weaponRender = FindObjectOfType<Sword_Trigger>().gameObject.transform.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        /*
        alphaValue -= 0.01f;
        image.color = new Color(image.color.r, image.color.g, image.color.b,
                alphaValue);
        */
    }

    public void OnClickWarrior()
    {
        Debug.Log("전직 : 전사");
        player.AddComponent<Class_Warrior>();
        weaponRender.sprite = weaponImage[0];
        Destroy(player.GetComponent<PlayerClass>());
        player.GetComponent<Player_Controller_L>().job = player.GetComponent<Class_Warrior>();
        Dim.SetActive(false);
        JobButton.SetActive(false);
        Cursor.SetCursor(warriorCursor, new Vector2(warriorCursor.width / 2, warriorCursor.height / 2), CursorMode.ForceSoftware);
        Time.timeScale = 1;
    }
    public void OnClickMagician()
    {
        Debug.Log("전직 : 마법사");
        player.AddComponent<Class_Magician>();
        weaponRender.sprite = weaponImage[1];
        Destroy(player.GetComponent<PlayerClass>());
        player.GetComponent<Player_Controller_L>().job = player.GetComponent<Class_Magician>();
        Dim.SetActive(false);
        JobButton.SetActive(false);
        Cursor.SetCursor(mageCursor, new Vector2(mageCursor.width / 2, mageCursor.height / 2), CursorMode.ForceSoftware);
        Time.timeScale = 1;
    }
}
