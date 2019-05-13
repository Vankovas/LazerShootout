using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerP2 : MonoBehaviour
{
    public float lazerSpeed;
    public GameObject lazerEffect;

    private Rigidbody2D rigi;
    
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rigi.velocity = new Vector2(lazerSpeed * transform.localScale.x/4, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player1") {
            FindObjectOfType<GameManager>().HurtP1();
        }
        else if(other.tag == "Player2") {
            //Do nothing
        }

        Instantiate(lazerEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
