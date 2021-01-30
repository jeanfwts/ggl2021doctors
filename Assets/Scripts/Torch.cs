using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : Kindlable
{
    private void Start()
    {
        initKindlable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // la torche s'allume au contact du projectile
        if (collision.GetComponent<Collider2D>().tag == "projectile" && !_torchLight.enabled)
        {
            Kindle();
        }
    }


}
