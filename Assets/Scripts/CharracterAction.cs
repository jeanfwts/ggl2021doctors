using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharracterAction : MonoBehaviour
{
    //public GameObject crosshairs;
    Vector3 target;
    public GameObject prefabLamp;
    public GameObject cam;

    public float bulletSpeed = 60.0f;

    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
     {
         target = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
         //crosshairs.transform.position = new Vector2(target.x, target.y);

         Vector3 difference = target - player.transform.position;
         float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         

         if (Input.GetMouseButtonDown(0))
         {
             Debug.Log(target.y +" " + target.x);
             float distance = difference.magnitude;
             Vector2 direction = difference / distance;
             direction.Normalize();
             fireLight(direction, rotationZ);
         }

     }
    
    void fireLight(Vector2 direction, float rotationZ)
    {
        GameObject light = Instantiate(prefabLamp) as GameObject;
        light.transform.position = player.transform.position;
        light.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        light.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
