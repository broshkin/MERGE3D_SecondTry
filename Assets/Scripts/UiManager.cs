using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class UiManager : MonoBehaviour
{
    public Button AdButton;
    public GameObject loseManager;

    private void Start()
    {
        AdButton.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }



    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.GetDataEvent -= GetData;
    }

    void Rewarded(int id)
    {
        if (id == 1)
        {
            Fruits.gameOver = false;
            GameObject.Find("1").transform.GetChild(0).gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Finish"));
            GameObject.Find("1").transform.GetChild(0).gameObject.GetComponent<Fruits>().CreateFruit();
            foreach (var a in Lose.destroyFruit)
            {
                Destroy(a);
            }    
            loseManager.SetActive(true);
            Time.timeScale *= 10;
            Time.fixedDeltaTime *= 10;
        }
    }

    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }    
    
    public async void GetData()
    {
        while (!YandexGame.SDKEnabled)
        {
            await Task.Delay(200);
        }
        Task.Delay(100);

        int a = Convert.ToInt32(YandexGame.savesData.maxScore);
        YandexGame.NewLeaderboardScores("LeaderBord3D", a);
    }
}