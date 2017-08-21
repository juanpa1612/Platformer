using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private Vector3 newPosition;

    public AudioClip coinSound;
    public GameObject gController;
    public GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gController = GameObject.Find("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameController.sumarScore("Moneda");
            gController.GetComponent<AudioSource>().clip = coinSound;
            gController.GetComponent<AudioSource>().Play();
        }

    }
}
