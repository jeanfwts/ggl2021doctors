using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("Player")[0];
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // la torche s'allume au contact du projectile
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            Destroy(_player);
        }
     
    }
}
