using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == collision.gameObject.tag && count < 2)
        {
            count++;
            NewFruits.pos += transform.position;
            NewFruits.fruit_tag = gameObject.tag;
            NewFruits.merge = true;
            Destroy(gameObject);
        }
    }
}
