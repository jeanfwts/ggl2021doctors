using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ContactToNotify : MonoBehaviour
{
    

    public UnityEvent collisionEnter = new UnityEvent();
    public UnityEvent collisionStay = new UnityEvent();
    public UnityEvent collisionExit = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionEnter.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collisionStay.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionExit.Invoke();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter.Invoke();
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisionStay.Invoke();
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionExit.Invoke();
        
    }
}
