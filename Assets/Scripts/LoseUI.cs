using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour
{
    public GameObject canvas;
    public List<string> tags = new List<string> { "Apple", "Watermelon", "Lemon", "Strawberry", "Cherry", "Avocado", "Peanut", "Pear", "Peach", "Banana" };
    public GameObject loseManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fruits.gameOver)
        {
            if (Score.timely_score == 0)
            {
                canvas.SetActive(true);
            }
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    public void LoxButton()
    {
        SaveManager.MySave();
        Fruits.gameOver = false;
        Score.total_score = 0;
        GameObject.Find("1").transform.GetChild(0).gameObject.SetActive(true);
        loseManager.SetActive(true);
        Destroy(GameObject.FindGameObjectWithTag("Finish"));
        foreach (var a in tags)
        {
            foreach (var b in GameObject.FindGameObjectsWithTag(a))
            {
                Destroy(b);
            }
        }
        GameObject.Find("1").transform.GetChild(0).gameObject.GetComponent<Fruits>().CreateFruit();
        Time.timeScale *= 10;
        Time.fixedDeltaTime *= 10;
    }
}
