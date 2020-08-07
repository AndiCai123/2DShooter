using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            dead = true;
            die();
        }
    }

    void onCollisionEnter2D(Collision2D other)
    {

    }

    void die()
    {

    }
}
