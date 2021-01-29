using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float TimeToLive = 5f;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToLive);
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
