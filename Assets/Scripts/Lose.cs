using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public List<string> tags = new List<string> { "Apple", "Watermelon", "Lemon", "Strawberry", "Cherry", "Avocado", "Peanut", "Pear", "Peach", "Banana" };

    public GameObject defeatSound;
    public GameObject defeatCamera;
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
            Time.timeScale /= 10;
            Time.fixedDeltaTime /= 10;
            Instantiate(defeatSound);
            var a = Instantiate(defeatCamera);
            a.GetComponent<DefeatCameraPos>().papa = other.gameObject;
            Camera.main.gameObject.SetActive(false);
            Fruits.gameOver = true;
            Destroy(Fruits.fruit);
            gameObject.SetActive(false);
        }    
    }
}
