using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject deathTrigger;
    public Vector3 posA, posB, posInicial, newPosition;
    private Vector3 scale;

	void Start ()
    {
        posInicial = transform.position;
        deathTrigger = GameObject.Find("DeathTrigger");
        scale = transform.localScale;
        posB = new Vector3(transform.position.x + 8f, transform.position.y);
        newPosition = posB;

	}
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        
        if (transform.position.x >= posB.x - 0.5)
        {
            newPosition = posInicial;
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (transform.position.x <= posInicial.x + 0.5)
        {
            newPosition = posB;
            scale.x *= -1;
            transform.localScale = scale; 
        }
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            deathTrigger.GetComponent<DeathTrigger>().Dead();
        }
    }

}
