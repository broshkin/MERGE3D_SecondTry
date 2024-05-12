using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }    
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveCloud;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;

    }

    public void LoadSaveCloud()
    {
        
    }

    public static void MySave()
    {
        YandexGame.savesData.maxScore = Mathf.Max(Score.total_score, YandexGame.savesData.maxScore);
        YandexGame.SaveProgress();
    }
}
