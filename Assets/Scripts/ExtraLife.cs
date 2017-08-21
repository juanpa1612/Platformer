using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    private GameController gController;
    public AudioClip liveSound;

    private void Awake()
    {
        gController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gController.SumarVida();
            gController.sumarScore("VidaExtra");
            gameObject.SetActive(false);
            gController.GetComponent<AudioSource>().clip = liveSound;
            gController.GetComponent<AudioSource>().Play();

        }
    }

}
