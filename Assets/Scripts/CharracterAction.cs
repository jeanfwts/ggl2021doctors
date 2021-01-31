using Cinemachine;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CharracterAction : MonoBehaviour
{
    public Projectile[] lamps = new Projectile[3];
    public GameObject cam;

    public float projectileSpeed = 700f;
    public int maxLampDistance = 10;

    private int currentlyHoldProjective;
    public int maxProjectileHold = 3;

    Vector3 target;
    Rigidbody2D player;
    CinemachineTargetGroup ctg;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        ctg = FindObjectOfType<CinemachineTargetGroup>();
        
        //ContactToNotify attackZone = transform.GetChild(0).Find("attackZone").GetComponent<ContactToNotify>();

        currentlyHoldProjective = maxProjectileHold;
    }

    void Update()
    {
        target = cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        if (Input.GetMouseButtonDown(1) && currentlyHoldProjective-- > 0)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireLight(direction, rotationZ);

        }
        else
        {
            //TODO animation fail
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            StartCoroutine(Attack());
        }
    }

    private void LateUpdate()
    {
        FollowingCameraDecision(0);
        FollowingCameraDecision(1);
        FollowingCameraDecision(2);
    }

    private void FollowingCameraDecision(int lampIndex)
    {
        if (Vector2.Distance(lamps[lampIndex].transform.position, transform.position) > maxLampDistance)
        {
            ctg.m_Targets[lampIndex+1].target = null;
        }
        else
        {
            if(ctg.m_Targets.Length <= lampIndex)
                ctg.m_Targets[lampIndex+1].target = lamps[lampIndex].transform;
        }
    }

    IEnumerator Attack()
    {
        // smoothly kindle the torch
        CircleCollider2D attackZone = transform.GetChild(0).Find("attackZone").gameObject.GetComponent<CircleCollider2D>();
        attackZone.enabled = true;
        yield return new WaitForSeconds(0.5f);
        attackZone.enabled = false;
    }

    void FireLight(Vector2 direction, float rotationZ)
    {
        Projectile proj = FindReadyLight();
        if (proj != null)
        {
            GameObject light = proj.gameObject;
            light.transform.position = player.transform.position;
            light.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            light.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    Projectile FindReadyLight()
    {
        Projectile projReady = lamps.FirstOrDefault(p => p.ready == true);
        if (projReady != null)
        {
            projReady.character = transform;
            projReady.Throw();
        }
        return projReady;
    }

    public void refill()
    {
        currentlyHoldProjective = maxProjectileHold;
    }
}
