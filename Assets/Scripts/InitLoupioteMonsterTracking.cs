using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLoupioteMonsterTracking : MonoBehaviour
{

    private bool _moving;
    private Torch _loupiote;

    // Start is called before the first frame update
    void Start()
    {
        _moving = false;
        _loupiote = transform.Find("MonstreALoupiote sans AI").GetComponent<Torch>();
    }

    private void Update()
    {
        if (!_moving && _loupiote.GetLitUp())
        {
            Debug.Log("Loupiote begin to move toward the player...");
            _moving = true;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GetComponent<AIDestinationSetter>().target = player.transform;
        }
    }

}
