using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour
{
    public GameObject teleportPosition = null;
    Vector2 position;

    public Collider2D targetBound;
    public CameraManager theCamera;
    public AudioClip[] clip = new AudioClip[2];
    private void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        position = teleportPosition.transform.position;
        clip[0] = SoundManager.instance.bglist[2];
        clip[1] = SoundManager.instance.bglist[1];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = position + new Vector2(2, 2);
            theCamera.SetBound(targetBound);
            if (targetBound.name == "bound 리월")
            {
                Debug.Log("이동합니다.");
                SoundManager.instance.BgSoundPlay(clip[0]);
            }
            else if (targetBound.name == "bound 몬드")
            {
                Debug.Log("이동합니다.");
                SoundManager.instance.BgSoundPlay(clip[1]);
            }
        }
    }
}
