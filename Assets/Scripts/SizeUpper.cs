using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpper : MonoBehaviour
{
    public Vector3 startSize;
    // Start is called before the first frame update
    void Start()
    {
        startSize = transform.localScale;
        transform.localScale /= 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x < startSize.x)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * 2;
        }
        else
        {
            GetComponent<SizeUpper>().enabled = false;
        }    
    }
}
