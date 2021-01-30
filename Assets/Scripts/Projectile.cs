using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TimeToLive = 3f;
    public Transform character;
    public bool ready = true;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playerBottom = GameObject.FindGameObjectWithTag("BottomTriggerPlayer");
        if (player != null) Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        if (playerBottom != null) Physics2D.IgnoreCollision(playerBottom.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }

    public void Throw()
    {
        gameObject.SetActive(true);
        ready = false;
        StartCoroutine(Disapear());
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(TimeToLive);
        gameObject.SetActive(false);
        transform.position = character.position;
        ready = true;
    }
}
