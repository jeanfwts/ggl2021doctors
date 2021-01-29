using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    Transform target;

    private void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, 0.5f);
    }
}
