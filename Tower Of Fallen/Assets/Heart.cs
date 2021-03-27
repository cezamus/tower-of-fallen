﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    protected int heal = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyHearth()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerPlatformerController>().Healed(heal);
            DestroyHearth();
        }
        

    }

}
