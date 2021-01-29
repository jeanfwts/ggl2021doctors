using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float TimeToLive = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject playerBottom = GameObject.FindGameObjectWithTag("BottomTriggerPlayer");
        if (player != null) Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        if (playerBottom != null) Physics2D.IgnoreCollision(playerBottom.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Destroy(gameObject, TimeToLive);
    }
}
