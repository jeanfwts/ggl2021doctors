using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampVision : MonoBehaviour
{
    private GameObject _player;
    public GameObject enemy;
    public GameObject enemySansIA;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Player")
        {
            enemySansIA.GetComponent<KindableChampVision>().isTriggered = true;
            enemy.GetComponent<AIDestinationSetter>().target = _player.transform;
        }
    }
}
