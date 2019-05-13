using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerP1 : MonoBehaviour
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
            //Nothing
        }
        else if(other.tag == "Player2") {
            FindObjectOfType<GameManager>().HurtP2();
        }

        Instantiate(lazerEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
