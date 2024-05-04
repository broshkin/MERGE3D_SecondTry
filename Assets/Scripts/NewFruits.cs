using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFruits : MonoBehaviour
{
    public static bool merge = false;
    public static string fruit_tag;
    public static Vector3 pos;
    public GameObject[] fruits;
    public GameObject merge_sound;
    public GameObject merge_particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (merge)
        {
            GameObject a = gameObject;
            Instantiate(merge_sound);
            Instantiate(merge_particle, pos / 2, transform.rotation);
            if (fruit_tag == "Cherry")
            {
                a = Instantiate(fruits[0], pos / 2, fruits[0].transform.rotation);
                merge = false;
                Score.score = 10;
            }
            if (fruit_tag == "Strawberry")
            {
                a = Instantiate(fruits[1], pos / 2, fruits[1].transform.rotation);
                merge = false;
                Score.score = 20;
            }
            if (fruit_tag == "Apple")
            {
                a = Instantiate(fruits[2], pos / 2, fruits[2].transform.rotation);
                merge = false;
                Score.score = 40;
            }
            if (fruit_tag == "Banana")
            {
                a = Instantiate(fruits[3], pos / 2, fruits[3].transform.rotation);
                merge = false;
                Score.score = 80;
            }
            if (fruit_tag == "Lemon")
            {
                a = Instantiate(fruits[4], pos / 2, fruits[4].transform.rotation);
                merge = false;
                Score.score = 160;
            }
            if (fruit_tag == "Peach")
            {
                a = Instantiate(fruits[5], pos / 2, fruits[5].transform.rotation);
                merge = false;
                Score.score = 320;
            }
            if (fruit_tag == "Pear")
            {
                a = Instantiate(fruits[6], pos / 2, fruits[6].transform.rotation);
                merge = false;
                Score.score = 640;
            }
            if (fruit_tag == "Avocado")
            {
                a = Instantiate(fruits[7], pos / 2, fruits[7].transform.rotation);
                merge = false;
                Score.score = 1280;
            }
            if (fruit_tag == "Peanut")
            {
                a = Instantiate(fruits[8], pos / 2, fruits[8].transform.rotation);
                merge = false;
                Score.score = 2560;
            }
            a.AddComponent<SizeUpper>();
            pos = new Vector3(0, 0, 0);
            Merge.count = 0;
            //if (fruit_tag == "Watermelon")
            //{
            //    Instantiate(fruits[9], pos, fruits[9].transform.rotation);
            //    merge = false;
            //}
        }
    }
}
