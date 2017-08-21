using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameController gController;
    public AudioClip checkpointSound;

    private void Awake()
    {
        gController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gController.sumarScore("Checkpoint");
            if (SceneManager.GetActiveScene().buildIndex <= 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                gController.GetComponent<AudioSource>().clip = checkpointSound;
                gController.GetComponent<AudioSource>().Play();
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
