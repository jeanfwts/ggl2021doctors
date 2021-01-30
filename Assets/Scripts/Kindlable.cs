using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Kindlable : MonoBehaviour
{
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float maxRadius = 0.4f;
    [SerializeField] private float kindleSpeed = 0.01f;

    protected Light2D _torchLight;
    protected bool _litUp;

    protected void initKindlable()
    {
        _litUp = false;
        _torchLight = GetComponent<Light2D>();
        _torchLight.enabled = false;
        _torchLight.intensity = 0f;
        _torchLight.pointLightOuterRadius = 0f;
    }


    public bool GetLitUp()
    {
        return _litUp;
    }

    protected void Kindle()
    {
        _litUp = true;
        _torchLight.enabled = true;
        StartCoroutine(ExpendRadius());
        StartCoroutine(InscreaseIntensity());
    }

    IEnumerator ExpendRadius()
    {
        // smoothly kindle the torch
        while (_torchLight.intensity < maxIntensity)
        {
            _torchLight.intensity += kindleSpeed * maxIntensity;
            yield return null;
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
