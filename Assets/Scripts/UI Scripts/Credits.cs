using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {


    private int finalScore;

    public Text txtScore;
	// Use this for initialization
	void Start ()
    {
        finalScore = PlayerPrefs.GetInt("CurrentScore");
        txtScore.text = finalScore.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");
        }
	}
}
