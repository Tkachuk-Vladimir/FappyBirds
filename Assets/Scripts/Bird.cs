﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 100f;
    public bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("flap");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("die");
        GameControl.instance.BirdDied();
    }
}
