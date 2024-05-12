using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class WinnerChickenDinner : MonoBehaviour
{
    public GameObject winCanvas;

    public TextMeshProUGUI score;
    public TextMeshProUGUI record;

    public Score scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fruits.gameOver)
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.002f;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }


    public void Win()
    {
        Fruits.gameOver = true;
        LoseUI.count = -1;
        winCanvas.SetActive(true);
        SaveManager.MySave();
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
    }
}
