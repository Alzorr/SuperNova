﻿using UnityEngine;
using System.Collections;

public class smallRockScript : MonoBehaviour
{
    public gameManager gameManager;
    private GameObject me;
    private float mySpeed;
    public Collider theSun;
    public Collider theShip;

    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<gameManager>();
        me = this.gameObject;
        mySpeed = gameManager.rockSpeed + Random.Range(gameManager.rockSpeed * 0.75f, gameManager.rockSpeed * 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        me.transform.Translate(Vector3.left * mySpeed);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Destroy me");    
        if (collision.tag == "Player")
        {
            collision.GetComponent<shipScript>().smallRockEffect();
            Destroy(me);
        }
        if (collision.tag == "sun")
            Destroy(me);
    }
}
