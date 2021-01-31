using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KindableChampVision : Kindlable
{
    public bool isTriggered;
    private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        initKindlable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && isFirst)
        {
            Kindle();
            isFirst = false;
        }
    }
}
