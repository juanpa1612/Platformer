using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeIn : MonoBehaviour
{
    public float fadingTime;
    private Color initialColor;
    private bool resetAlpha;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 1);
        fadingTime = 30;
        initialColor = gameObject.GetComponent<Image>().color;
        resetAlpha = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (resetAlpha == true)
        {
            gameObject.GetComponent<Image>().CrossFadeAlpha(0, 0.8f, false);
            Invoke("FadeOut", 2);
        }
	}
    public void FadeOut ()
    {
        resetAlpha = false;
    }
    public void ResetAlpha ()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.8f);
        resetAlpha = true;
    }
}
