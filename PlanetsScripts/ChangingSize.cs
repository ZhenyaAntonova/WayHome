using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSize : MonoBehaviour
{
    public float range = 7.0f;
    private float higherBound;
    private float lowerBound;
    private float changeUnit = 0.2f;
    private Vector3 change;
    private bool tooBig = false;

    private void Start()
    {
        higherBound = transform.localScale.x + range;
        lowerBound = transform.localScale.x - range;
        change = new Vector3(changeUnit, changeUnit, changeUnit);
    }

    private void Update()
    {
        if(!tooBig)
        {
            GetBigger();
        }
        else
        {
            GetSmaller();
        }
    }

    private void GetBigger()
    {
        gameObject.transform.localScale += change;

        if (transform.localScale.x >= higherBound)
        {
            tooBig = true;
        }
    }

    private void GetSmaller()
    {
        gameObject.transform.localScale -= change;

        if (transform.localScale.x <= lowerBound)
        {
            tooBig = false;
        }
    }
}
