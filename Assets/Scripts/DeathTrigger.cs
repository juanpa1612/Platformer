using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

    public GameController gameController;

    public GameObject player;
    public GameObject fadeIn;
    public GameObject platform;

    public AudioClip deadSound;

    public bool dead = false;

    private Vector3 posInicial;
    private bool restoVida;

    private void Start()
    {
        posInicial = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dead();
        }
    }

    public void Dead ()
    {
        player.transform.position = posInicial;
        gameController.PerderVida();
        fadeIn.GetComponent<FadeIn>().ResetAlpha();
        dead = true;
        Invoke("ResetDead", 1);

        GameObject.Find("GameController").GetComponent<AudioSource>().clip = deadSound;
        GameObject.Find("GameController").GetComponent<AudioSource>().Play();
    }

    private void ResetDead ()
    {
        dead = false;
    }
}
