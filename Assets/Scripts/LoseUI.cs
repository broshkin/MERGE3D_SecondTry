using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

public class LoseUI : MonoBehaviour
{
    public GameObject canvas;
    public GameObject adButton;
    public List<string> tags = new List<string> { "Apple", "Watermelon", "Lemon", "Strawberry", "Cherry", "Avocado", "Peanut", "Pear", "Peach", "Banana" };
    public GameObject loseManager;
    public static int count = -1;

    public TextMeshProUGUI score;
    public TextMeshProUGUI record;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fruits.gameOver)
        {
            if (Score.timely_score == 0 && !NewFruits.winnig)
            {
                canvas.SetActive(true);
                if (YandexGame.EnvironmentData.language == "ru")
                {
                    score.text = "Счёт: " + Score.total_score.ToString();
                    record.text = "Рекорд: " + YandexGame.savesData.maxScore.ToString();
                }
                if (YandexGame.EnvironmentData.language == "en")
                {
                    score.text = "Score: " + Score.total_score.ToString();
                    record.text = "Record: " + YandexGame.savesData.maxScore.ToString();
                }
                if (YandexGame.EnvironmentData.language == "tr")
                {
                    score.text = "Gol: " + Score.total_score.ToString();
                    record.text = "Kayıt: " + YandexGame.savesData.maxScore.ToString();
                }
                if (count == 1)
                {
                    adButton.SetActive(false);
                }
                else
                {
                    adButton.SetActive(true);
                }
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
        count = -1;
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
        YandexGame.FullscreenShow();
    }
}
