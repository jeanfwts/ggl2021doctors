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
    public UnityEvent collisionEnterBis = new UnityEvent();
    public UnityEvent collisionStayBis = new UnityEvent();
    public UnityEvent collisionExitBis = new UnityEvent();

    public void OnTriggerEnter2D(Collider2D collider)
    {
        collisionEnter.Invoke(collider.gameObject);
        collisionEnterBis.Invoke();
        Debug.Log("triggerenter");
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        collisionStay.Invoke(collider.gameObject);
        collisionStayBis.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        collisionExit.Invoke(collider.gameObject);
        collisionExitBis.Invoke();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter.Invoke(collision.gameObject);
        collisionEnterBis.Invoke();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        collisionStay.Invoke(collision.gameObject);
        collisionStayBis.Invoke();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collisionExit.Invoke(collision.gameObject);
        collisionExitBis.Invoke();
    }
}
