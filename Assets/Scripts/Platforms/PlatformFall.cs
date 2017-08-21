using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 newPosition;
    private Animator animPlatform;
    private bool caida;

    private DeathTrigger deathTrigger;

    private void Awake()
    {
        initialPos = transform.position;
        newPosition = transform.position;
        animPlatform = GetComponent<Animator>();
        deathTrigger = GameObject.Find("DeathTrigger").GetComponent<DeathTrigger>();
    }

    private void Update()
    {
        if (caida)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
        }
        if (deathTrigger.dead == true)
        {
            ResetPosition();
        }
    }

    private void Fall ()
    {
        newPosition = new Vector3(transform.position.x, -20, 0);
        GetComponent<BoxCollider2D>().isTrigger = true;
        caida = true;
    }

    public void ResetPosition()
    {
        transform.position = initialPos;
        GetComponent<BoxCollider2D>().isTrigger = false;
        animPlatform.SetBool("ColorChange", false);
        caida = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animPlatform.SetBool("ColorChange", true);
            Invoke("Fall", 3f);
        }
    }
}
