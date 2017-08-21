using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup hud;
    private bool tutorial;

	// Use this for initialization
	void Start ()
    {
        hud.alpha = 0;
        tutorial = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (tutorial == true)
        {
            if (Input.anyKeyDown)
            {
                GetComponent<Image>().CrossFadeAlpha(0, 1, false);
                hud.alpha = 1;
                Invoke("Destruir",1.5f);
            }
        }

        if (hud.alpha == 1)
        {
            tutorial = false;
        }
	}

    void Destruir ()
    {
        gameObject.SetActive(false);
    }
}
