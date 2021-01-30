using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharracterAction : MonoBehaviour
{
    //public GameObject crosshairs;
    Vector3 target;
    public GameObject prefabLamp;
    public GameObject cam;

    public float maxProjectile = 5f;
    public float projectileSpeed = 700f;

    public int maxProjectileHold = 3;
    private int _currentlyHoldProjective { get; set; }

    Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        _currentlyHoldProjective = 3;
        player = GetComponent<Rigidbody2D>();
        ContactToNotify attackZone = transform.GetChild(0).Find("attackZone").GetComponent<ContactToNotify>();
        Debug.Log("Remaining projectives: " + _currentlyHoldProjective);
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
            if(_currentlyHoldProjective > 0)
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                FireLight(direction, rotationZ);
                _currentlyHoldProjective--;
                Debug.Log("Remaining projectives: " + _currentlyHoldProjective);
            }
            else
            {
                Debug.Log("play animation of firing the projecture failure");
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack");
            StartCoroutine(attack());
        }
    }

    IEnumerator attack()
    {
        // smoothly kindle the torch
        CircleCollider2D attackZone = transform.GetChild(0).Find("attackZone").gameObject.GetComponent<CircleCollider2D>();
        attackZone.enabled = true;
        yield return new WaitForSeconds(0.5f);
        attackZone.enabled = false;
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
