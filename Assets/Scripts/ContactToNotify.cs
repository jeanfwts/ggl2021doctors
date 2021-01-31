using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : UnityEvent<GameObject>
{

}

[RequireComponent(typeof(Collider2D))]
public class ContactToNotify : MonoBehaviour
{
    

    public CollisionEvent collisionEnter = new CollisionEvent();
    public CollisionEvent collisionStay = new CollisionEvent();
    public CollisionEvent collisionExit = new CollisionEvent();

    public void OnTriggerEnter2D(Collider2D collider)
    {
        collisionEnter.Invoke(collider.gameObject);
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        collisionStay.Invoke(collider.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        collisionExit.Invoke(collider.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter.Invoke(collision.gameObject);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        collisionStay.Invoke(collision.gameObject);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collisionExit.Invoke(collision.gameObject);
    }
}
