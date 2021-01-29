using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float maxRadius = 0.4f;
    [SerializeField] private float kindleSpeed = 0.01f;

    private Light2D _torchLight;
    private bool _litUp = false;

    void Start()
    {
        _torchLight = GetComponent<Light2D>();
        _torchLight.enabled = false;
        _torchLight.intensity = 0f;
        _torchLight.pointLightOuterRadius = 0f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // la torche s'allume au contact du projectile
        if (collision.GetComponent<Collider2D>().tag == "projectile" && !_torchLight.enabled)
        {
            Debug.Log("Triggered by projectile");
            _torchLight.enabled = true;
            Kindle();
        }
    }

    void Kindle()
    {
        StartCoroutine(ExpendRadius());
        StartCoroutine(InscreaseIntensity());
    }

    IEnumerator ExpendRadius()
    {
        // smoothly kindle the torch
        while (_torchLight.intensity < maxIntensity )
        {
            _torchLight.intensity += kindleSpeed * maxIntensity;
            yield return  null;
        }
    }

    IEnumerator InscreaseIntensity()
    {
        // smoothly kindle the torch
        while (_torchLight.pointLightOuterRadius < maxRadius)
        {
            _torchLight.pointLightOuterRadius += kindleSpeed * maxRadius;
            yield return null;
        }

    }

}
