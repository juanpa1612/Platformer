using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeIn;

    private void Start()
    {
        fadeIn.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        fadeIn.GetComponent<Image>().CrossFadeAlpha(0, 1.5f, false);
        Invoke("DesactivateFade", 1.5f);

        PlayerPrefs.SetInt("CurrentLives",3);
        PlayerPrefs.SetInt("CurrentScore", 0);
    }
    private void DesactivateFade ()
    {
        fadeIn.SetActive(false);
    }
    public void btnPlay ()
    {
        SceneManager.LoadScene("Level1");
    }

}
