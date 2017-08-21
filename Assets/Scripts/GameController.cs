using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject spriteVidas;
    public Text txtScore;
    public Text GameOverText;
    public CanvasGroup GameoverGroup;
    public AudioClip checkpoint;

    private Animator animVidas;

    private int vidas;
    private int score;

    private void Update()
    {
        spriteVidas.GetComponent<Animator>().SetInteger("Vidas", vidas);
        txtScore.text = score.ToString();
    }

    private void Start()
    {
        GetComponent<AudioSource>().clip = checkpoint;
        GetComponent<AudioSource>().Play();
        animVidas = spriteVidas.GetComponent<Animator>();
        vidas = PlayerPrefs.GetInt("CurrentLives");
        score = PlayerPrefs.GetInt("CurrentScore");
        txtScore.text = score.ToString();
    }

    public void SumarVida ()
    {
        if (vidas < 3)
        {
            vidas += 1;
            PlayerPrefs.SetInt("CurrentLives", vidas);
        }
    }
    public void PerderVida()
    {
        if (vidas >0)
        {
            vidas -= 1;
            PlayerPrefs.SetInt("CurrentLives", vidas);
        }
        else
        {
            GameoverGroup.gameObject.SetActive(true);
            GameOverText.GetComponent<Animator>().SetBool("GameOver", true);
            Invoke("GameOver", 4);
        }
    }
    public void GameOver ()
    {
        SceneManager.LoadScene("Credits");
    }
    public void sumarScore (string recompensa)
    {
        if (recompensa == "Moneda")
        {
            score += 50;
            PlayerPrefs.SetInt("CurrentScore", score);
        }
        if (recompensa == "Checkpoint")
        {
            score += 200;
            PlayerPrefs.SetInt("CurrentScore", score);
        }
        if (recompensa == "VidaExtra")
        {
            score += 100;
            PlayerPrefs.SetInt("CurrentScore", score);
        }
    }
}
