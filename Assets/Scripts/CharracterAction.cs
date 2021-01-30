using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharracterAction : MonoBehaviour
{
    //public GameObject crosshairs;
    Vector3 target;
    public GameObject prefabLamp;
    public GameObject cam;

    public float maxProjectile = 3f;
    public float projectileSpeed = 700f;

    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        ContactToNotify attackZone = transform.GetChild(0).Find("attackZone").GetComponent<ContactToNotify>();
  
    }

    // Update is called once per frame
    void Update()
     {
         target = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
         //crosshairs.transform.position = new Vector2(target.x, target.y);

         Vector3 difference = target - player.transform.position;
         float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        if (Input.GetMouseButtonDown(1) && GameObject.FindGameObjectsWithTag("projectile").Length < maxProjectile)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireLight(direction, rotationZ);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack");
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        Debug.Log("attackTest");
        // smoothly kindle the torch
        CircleCollider2D attackZone = transform.GetChild(0).Find("attackZone").gameObject.GetComponent<CircleCollider2D>();
        attackZone.enabled = true;
        yield return new WaitForSeconds(0.5f);
        attackZone.enabled = false;
        Debug.Log("attackOk");
    }

    void FireLight(Vector2 direction, float rotationZ)
    {
        GameObject light = Instantiate(prefabLamp, prefabLamp.transform.position, prefabLamp.transform.rotation);
        light.transform.position = player.transform.position;
        light.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        //light.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        light.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
    }
}
