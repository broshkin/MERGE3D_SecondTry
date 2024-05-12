using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public List<string> tags = new List<string> { "Apple", "Watermelon", "Lemon", "Strawberry", "Cherry", "Avocado", "Peanut", "Pear", "Peach", "Banana" };

    public GameObject defeatSound;
    public GameObject defeatCamera;
    public static List<GameObject> destroyFruit = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            Instantiate(defeatSound);
            var a = Instantiate(defeatCamera);
            a.GetComponent<DefeatCameraPos>().papa = other.gameObject;
            destroyFruit.Add(other.gameObject);
            Camera.main.gameObject.SetActive(false);
            Fruits.gameOver = true;
            Destroy(Fruits.fruit);
            LoseUI.count++;
            gameObject.SetActive(false);
        }    
    }
}
