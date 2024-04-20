using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatCameraPos : MonoBehaviour
{
    public GameObject papa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(papa.transform.position.x, papa.transform.position.y + 0.3f, papa.transform.position.z + 0.3f);
    }
}
