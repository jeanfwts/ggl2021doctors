using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
{

    [SerializeField] private float kindleSpeed = 0.01f;

    private Light2D _torchLight;
    private bool _litUp = false;

    void Start()
    {
        _torchLight = GetComponent<Light2D>();
        _torchLight.enabled = false;
        _torchLight.intensity = 0f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // la torche s'allume au contact du projectile
        if (collision.GetComponent<Collider2D>().tag == "projectile" && !_torchLight.enabled)
        {
            Debug.Log("Triggered by projectile");
            _torchLight.enabled = true;
            StartCoroutine(Kindle());
        }
    }

    IEnumerator Kindle()
    {
        Debug.Log("light intensity: " + _torchLight.intensity);
        // smoothly kindle the torch
        while (_torchLight.intensity < 1.0f && !_litUp)
        {
            _torchLight.intensity += kindleSpeed;
            yield return  null;
        }

        _litUp = true;
    }

}
