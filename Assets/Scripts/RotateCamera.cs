using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down, horizontalInput * 100 * Time.deltaTime);
    }

    public void RotRight()
    {
        transform.Rotate(Vector3.down, 100 * Time.deltaTime);
    }
    public void RotLeft()
    {
        transform.Rotate(Vector3.down, -100 * Time.deltaTime);
    }
}
