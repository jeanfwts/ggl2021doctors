using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destryable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Collider2D>().tag == "Sword")
        {
            Destroy(gameObject);
        }
    }
}
