using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemies : MonoBehaviour
{
    public GameObject enemy;

    Rigidbody2D rgbd;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = enemy.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rgbd.AddForce(-enemy.transform.right * 50f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Monster")
        {
            if (enemy.transform.rotation.y == 0)
            {
                enemy.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
            else
            {
                enemy.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }
    }
}
